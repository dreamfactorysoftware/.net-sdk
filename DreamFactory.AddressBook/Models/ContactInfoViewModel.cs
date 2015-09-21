namespace DreamFactory.AddressBook.Models
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Models.Entities;
    using DreamFactory.AddressBook.Properties;

    public class ContactInfoViewModel
    {
        public string ReturnUrl { get; set; }

        [Display(Name = "Contact info type")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        public InfoType InfoType { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public string ContactName { get; set; }
    }
}
