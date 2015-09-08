namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Extensions;
    using DreamFactory.AddressBook.Models.Contact;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;

    [Authorize]
    public class ContactController : Controller
    {
        private readonly IDatabaseApi databaseApi;

        public ContactController(IDatabaseApi databaseApi)
        {
            this.databaseApi = databaseApi;
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
                GroupId = groupId
            };

            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            IEnumerable<Contact> records = new List<Contact> { contact };
            records = (await databaseApi.CreateRecordsAsync("contact", records, new SqlQuery())).ToList();

            IEnumerable<ContactContactGroup> relationshipRecords = new List<ContactContactGroup>
                {
                    new ContactContactGroup
                    {
                        ContactId = records.Select(x => x.Id).First(),
                        ContactGroupId = contact.GroupId
                    }
                };

            await databaseApi.CreateRecordsAsync("contact_group_relationship", relationshipRecords, new SqlQuery());

            return RedirectToAction("List", Request.QueryString.ToRouteValues(new { GroupId = contact.GroupId }));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            SqlQuery query = new SqlQuery
            {
                Filter = "id = " + id
            };

            Contact contact = (await databaseApi.GetRecordsAsync<Contact>("contact", query)).FirstOrDefault();

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            return RedirectToAction("List", Request.QueryString.ToRouteValues(new { GroupId = contact.GroupId }));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            SqlQuery query = new SqlQuery
            {
                Filter = "id = " + id
            };

            Contact contact = (await databaseApi.GetRecordsAsync<Contact>("contact", query)).FirstOrDefault();

            return View(contact);
        }
    }
}