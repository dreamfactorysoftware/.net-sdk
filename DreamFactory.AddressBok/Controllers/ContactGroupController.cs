namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models;
    using DreamFactory.AddressBook.Models.Contact;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;

    [Authorize]
    [HandleError]
    public class ContactGroupController : Controller
    {
        private readonly IDatabaseApi databaseApi;

        public ContactGroupController(IDatabaseApi databaseApi)
        {
            this.databaseApi = databaseApi;
        }

        [HttpGet]
        public async Task<ActionResult> List(int offset = 0, int limit = 10)
        {
            IEnumerable<ContactGroup> groups = (await databaseApi.GetRecordsAsync<ContactGroup>("contact_group", new SqlQuery())).ToList();

            ViewBag.Page = offset / limit + 1;
            ViewBag.PageSize = limit;
            ViewBag.TotalResults = groups.Count();

            groups = groups.Skip(offset).Take(limit);

            return View(groups);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            List<ContactContactGroupViewModel> contacts = (await databaseApi.GetRecordsAsync<Contact>("contact", new SqlQuery()))
                .Select(x => new ContactContactGroupViewModel
                {
                    ContactId = x.Id.Value,
                    ContactName = string.Format("{0} {1}", x.FirstName, x.LastName),
                    InGroup = false
                }).ToList();

            ContactGroupViewModel model = new ContactGroupViewModel
            {
                ContactGroup = new ContactGroup(),
                Contacts = contacts
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IEnumerable<ContactGroup> records = await databaseApi.CreateRecordsAsync("contact_group", new List<ContactGroup> { model.ContactGroup }, new SqlQuery());

            IEnumerable<ContactContactGroup> relationshipModel = model.Contacts
                .Select(x => new ContactContactGroup
                {
                    ContactId = x.ContactId,
                    ContactGroupId = records.Select(y => y.Id).FirstOrDefault()
                });

            await databaseApi.CreateRecordsAsync("contact_group_relationship", relationshipModel, new SqlQuery());

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            SqlQuery groupQuery = new SqlQuery
            {
                Filter = "id = " + id
            };

            SqlQuery contactsInGroupQuery = new SqlQuery
            {
                Filter = "contact_group_id = " + id
            };

            ContactGroup contactGroup = (await databaseApi.GetRecordsAsync<ContactGroup>("contact_group", groupQuery)).FirstOrDefault();

            List<ContactContactGroupViewModel> contacts = (await databaseApi.GetRecordsAsync<Contact>("contact", new SqlQuery()))
                .Select(x => new ContactContactGroupViewModel
                {
                    ContactId = x.Id.Value,
                    ContactName = string.Format("{0} {1}", x.FirstName, x.LastName),
                    InGroup = false
                })
                .ToList();

            List<ContactContactGroup> contactsInGroup = (await databaseApi.GetRecordsAsync<ContactContactGroup>("contact_group_relationship", contactsInGroupQuery)).ToList();

            foreach (ContactContactGroup relationship in contactsInGroup)
            {
                contacts.FirstOrDefault(x => x.ContactId == relationship.ContactId.Value).InGroup = true;
            }

            ContactGroupViewModel model = new ContactGroupViewModel
            {
                ContactGroup = contactGroup,
                Contacts = contacts
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ContactGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SqlQuery contactsInGroupQuery = new SqlQuery
            {
                Filter = "contact_group_id = " + model.ContactGroup.Id
            };

            databaseApi.UpdateRecordsAsync("contact_group", new List<ContactGroup> { model.ContactGroup });

            ContactContactGroup tmp;

            Dictionary<int, ContactContactGroup> relationshipsInDb = 
                (await databaseApi.GetRecordsAsync<ContactContactGroup>("contact_group_relationship", contactsInGroupQuery))
                .ToDictionary(x => x.ContactId.Value, x => x);
            Dictionary<int, ContactContactGroup> relationshipsInModel = 
                model.Contacts
                .Where(x => x.InGroup)
                .ToDictionary(x => x.ContactId, x => new ContactContactGroup
                {
                    ContactGroupId = model.ContactGroup.Id,
                    ContactId = x.ContactId
                });

            List<ContactContactGroup> relationshipsToDelete = 
                relationshipsInDb.Values
                .Where(relationship => !relationshipsInModel.TryGetValue(relationship.ContactId.Value, out tmp))
                .ToList();

            List<ContactContactGroup> relationshipsToAdd = 
                relationshipsInModel.Values
                .Where(relationship => !relationshipsInDb.TryGetValue(relationship.ContactId.Value, out tmp))
                .ToList();

            databaseApi.CreateRecordsAsync("contact_group_relationship", relationshipsToAdd, new SqlQuery());
            databaseApi.DeleteRecordsAsync("contact_group_relationship", relationshipsToDelete);

            return RedirectToAction("List");
        }
    }
}