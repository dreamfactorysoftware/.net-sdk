namespace DreamFactory.AddressBook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using DreamFactory.AddressBook.Models.Entities;

    public class ContactViewModel
    {
        public int? GroupId { get; set; }

        [Display(Name = "Image URL")]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Contact Contact { get; set; }

        public List<ContactInfo> ContactInfos { get; set; }
        public string ImageData { get; set; }
    }
}
