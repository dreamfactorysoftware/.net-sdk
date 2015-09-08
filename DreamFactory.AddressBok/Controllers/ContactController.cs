namespace DreamFactory.AddressBook.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Extensions;
    using DreamFactory.AddressBook.Models;
    using DreamFactory.AddressBook.Models.Entities;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.File;

    [Authorize]
    [HandleError]
    public class ContactController : Controller
    {
        private readonly IDatabaseApi databaseApi;
        private readonly IFilesApi filesApi;

        private readonly string[] validImageTypes =
        {
            "image/gif",
            "image/jpeg",
            "image/pjpeg",
            "image/png"
        };

        public ContactController(IDatabaseApi databaseApi, IFilesApi filesApi)
        {
            this.databaseApi = databaseApi;
            this.filesApi = filesApi;
        }

        [HttpGet]
        public async Task<ActionResult> List(int? groupId, int offset = 0, int limit = 10)
        {
            SqlQuery query;
            SqlQuery relationshipQuery;
            Task<IEnumerable<ContactGroup>> contactGroupsTask = null;

            if (groupId.HasValue)
            {
                relationshipQuery = new SqlQuery
                {
                    Filter = "contact_group_id = " + groupId
                };

                query = new SqlQuery
                {
                    Filter = "id = " + groupId
                };
                contactGroupsTask = databaseApi.GetRecordsAsync<ContactGroup>("contact_group", query);
            }
            else
            {
                relationshipQuery = new SqlQuery();
            }

            IEnumerable<ContactContactGroup> contactContactGroups = (await databaseApi.GetRecordsAsync<ContactContactGroup>("contact_group_relationship", relationshipQuery)).ToList();

            IEnumerable<Contact> contacts = new List<Contact>();
            if (contactContactGroups.Any())
            {
                query = new SqlQuery
                {
                    Ids = string.Join(",", contactContactGroups.Select(x => x.ContactId.ToString()))
                };
                contacts = await databaseApi.GetRecordsAsync<Contact>("contact", query);
            }

            if (contactGroupsTask != null)
            {
                ViewBag.GroupName = (await contactGroupsTask).Select(x => x.Name).FirstOrDefault();
            }

            ViewBag.Page = offset / limit + 1;
            ViewBag.PageSize = limit;
            ViewBag.TotalResults = contacts.Count();

            return View(contacts);
        }

        [HttpGet]
        public ActionResult Create(int groupId)
        {
            ContactViewModel contact = new ContactViewModel
            {
                GroupId = groupId,
                Contact = new Contact(),
                ContactInfos = new List<ContactInfo>()
            };

            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactViewModel model)
        {
            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0 && !validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                MemoryStream target = new MemoryStream();
                model.ImageUpload.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                string base64Data = string.Format("data:{0};base64,{1}", model.ImageUpload.ContentType, Convert.ToBase64String(data));
                FileResponse result = await filesApi.CreateFileAsync(Guid.NewGuid().ToString(), base64Data);
                model.Contact.ImageUrl = result.Name;
            }

            IEnumerable<Contact> records = new List<Contact> { model.Contact };
            records = (await databaseApi.CreateRecordsAsync("contact", records, new SqlQuery())).ToList();

            IEnumerable<ContactContactGroup> relationshipRecords = new List<ContactContactGroup>
                {
                    new ContactContactGroup
                    {
                        ContactId = records.Select(x => x.Id).First(),
                        ContactGroupId = model.GroupId
                    }
                };

            await databaseApi.CreateRecordsAsync("contact_group_relationship", relationshipRecords, new SqlQuery());

            return RedirectToAction("List", Request.QueryString.ToRouteValues(new { GroupId = model.GroupId }));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            SqlQuery contactQuery = new SqlQuery
            {
                Filter = "id = " + id
            };

            SqlQuery contactInfoQuery = new SqlQuery
            {
                Filter = "contact_id = " + id
            };

            ContactViewModel model = new ContactViewModel
            {
                Contact = (await databaseApi.GetRecordsAsync<Contact>("contact", contactQuery)).FirstOrDefault(),
                ContactInfos = (await databaseApi.GetRecordsAsync<ContactInfo>("contact_info", contactInfoQuery)).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ContactViewModel model)
        {
            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0 && !validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            if (!ModelState.IsValid)
            {
                SqlQuery contactInfoQuery = new SqlQuery
                {
                    Filter = "contact_id = " + model.Contact.Id
                };

                model.ContactInfos = (await databaseApi.GetRecordsAsync<ContactInfo>("contact_info", contactInfoQuery)).ToList();
                return View(model);
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                MemoryStream target = new MemoryStream();
                model.ImageUpload.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                string base64Data = string.Format("data:{0};base64,{1}", model.ImageUpload.ContentType, Convert.ToBase64String(data));
                FileResponse result = await filesApi.CreateFileAsync(Guid.NewGuid().ToString(), base64Data);
                model.Contact.ImageUrl = result.Name;
            }

            await databaseApi.UpdateRecordsAsync("contact", new List<Contact> { model.Contact });

            return RedirectToAction("List", Request.QueryString.ToRouteValues(new { GroupId = model.GroupId }));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            SqlQuery contactQuery = new SqlQuery
            {
                Filter = "id = " + id
            };

            SqlQuery contactInfoQuery = new SqlQuery
            {
                Filter = "contact_id = " + id
            };

            Contact contact = (await databaseApi.GetRecordsAsync<Contact>("contact", contactQuery)).FirstOrDefault();
            string imageData = string.Empty;
            if (!string.IsNullOrEmpty(contact.ImageUrl))
            {
                imageData = await filesApi.GetTextFileAsync(contact.ImageUrl);
            }

            ContactViewModel model = new ContactViewModel
            {
                Contact = contact,
                ContactInfos = (await databaseApi.GetRecordsAsync<ContactInfo>("contact_info", contactInfoQuery)).ToList(),
                ImageData = imageData
            };

            return View(model);
        }
    }
}