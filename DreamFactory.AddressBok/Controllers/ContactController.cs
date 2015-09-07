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
            SqlQuery query = new SqlQuery
            {
                Limit = limit,
                Offset = offset * (limit - 1)
            };

            IEnumerable<Contact> contacts = await databaseApi.GetRecordsAsync<Contact>("contact", query);

            ViewBag.Page = offset / limit + 1;
            ViewBag.PageSize = limit;
            ViewBag.TotalResults = contacts.Count();

            return View(contacts);
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
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return View(contact);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details()
        {
            Contact group = new Contact();

            return View(group);
        }
    }
}