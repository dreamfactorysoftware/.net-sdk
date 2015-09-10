namespace DreamFactory.AddressBook.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models;
    using DreamFactory.AddressBook.Models.Entities;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;

    [Authorize]
    [HandleError]
    public class ContactInfoController : Controller
    {
        private readonly IDatabaseApi databaseApi;

        public ContactInfoController(IDatabaseApi databaseApi)
        {
            this.databaseApi = databaseApi;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int contactId, string returnUrl)
        {
            SqlQuery query = new SqlQuery
            {
                Filter = "id = " + contactId
            };

            Contact contact = (await databaseApi.GetRecordsAsync<Contact>("contact", query)).Records.FirstOrDefault();

            if (contact == null)
            {
                return Redirect(returnUrl);
            }

            ViewBag.ContactName = string.Format("{0} {1}", contact.FirstName, contact.LastName);

            ContactInfoViewModel model = new ContactInfoViewModel
            {
                ContactInfo = new ContactInfo { ContactId = contactId },
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactInfoViewModel model)
        {
            model.ContactInfo.InfoType = model.InfoType.ToString();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await databaseApi.CreateRecordsAsync("contact_info", new List<ContactInfo> { model.ContactInfo }, new SqlQuery());

            return Redirect(model.ReturnUrl);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id, string returnUrl)
        {
            SqlQuery contactInfoQuery = new SqlQuery
            {
                Filter = "id = " + id,
                Related = "contact_by_contact_id"
            };

            ContactInfo contactInfo = (await databaseApi.GetRecordsAsync<ContactInfo>("contact_info", contactInfoQuery)).Records.FirstOrDefault();

            if (contactInfo == null)
            {
                return Redirect(returnUrl);
            }

            ContactInfoViewModel model = new ContactInfoViewModel
            {
                InfoType = (InfoType)Enum.Parse(typeof(InfoType), contactInfo.InfoType, true),
                ContactInfo = contactInfo,
                ContactName = string.Format("{0} {1}", contactInfo.Contact.FirstName, contactInfo.Contact.LastName),
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ContactInfoViewModel model)
        {
            model.ContactInfo.InfoType = model.InfoType.ToString();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await databaseApi.UpdateRecordsAsync("contact_info", new List<ContactInfo> { model.ContactInfo }, new SqlQuery());

            return Redirect(model.ReturnUrl);
        }
    }
}