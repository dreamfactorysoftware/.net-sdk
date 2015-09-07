namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models.Contacts;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;

    [Authorize]
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
        public async Task<ActionResult> Edit(int id)
        {
            var query = new SqlQuery
            {
                Filter = "id = " + id
            };

            ContactGroup group = (await databaseApi.GetRecordsAsync<ContactGroup>("contact_group", query)).FirstOrDefault();

            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(ContactGroup group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ContactGroup group = new ContactGroup();

            return View(group);
        }

        [HttpPost]
        public ActionResult Create(ContactGroup group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }

            return RedirectToAction("List");
        }
    }
}