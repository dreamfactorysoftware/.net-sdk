namespace DreamFactory.AddressBook.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using DreamFactory.AddressBook.Models.Entities;

    public class ContactCreateViewModel
    {
        public int? GroupId { get; set; }

        [Display(Name = "Image URL")]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Contact Contact { get; set; }

        public ContactInfoViewModel ContactInfoViewModel { get; set; }
        public string ImageData { get; set; }
    }
}
