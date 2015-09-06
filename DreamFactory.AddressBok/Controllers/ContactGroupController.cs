namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models.ContactGroup;
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

        public async Task<ActionResult> List(int offset = 1, int limit = 10)
        {
            var query = new SqlQuery
            {
                Limit = limit,
                Offset = offset
            };

            //IEnumerable<ContactGroup> groups = await databaseApi.GetRecordsAsync<ContactGroup>("contact_group", query);

            var groups = new List<ContactGroup>
            {
                new ContactGroup { Id = 1, Name = "Army" },
                new ContactGroup { Id = 2, Name = "Army2" }
            };

            ViewBag.Page = offset / limit + 1;
            ViewBag.PageSize = limit;
            ViewBag.TotalResults = groups.Count();

            return View(groups);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var query = new SqlQuery
            {
                Filter = "id = " + id
            };

            ContactGroup group = (await databaseApi.GetRecordsAsync<ContactGroup>("contact_group", query)).FirstOrDefault();

            return View(group);
        }

        public ActionResult Create()
        {
            ContactGroup group = new ContactGroup();

            return View(group);
        }
    }
}