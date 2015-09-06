namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
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

        public async Task<ActionResult> List(int offset = 0, int limit = 10)
        {
            var query = new SqlQuery
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

        public async Task<ActionResult> Edit(int id)
        {
            var query = new SqlQuery
            {
                Filter = "id = " + id
            };

            Contact contact = (await databaseApi.GetRecordsAsync<Contact>("contact", query)).FirstOrDefault();

            return View(contact);
        }

        public ActionResult Details()
        {
            Contact group = new Contact();

            return View(group);
        }
    }
}