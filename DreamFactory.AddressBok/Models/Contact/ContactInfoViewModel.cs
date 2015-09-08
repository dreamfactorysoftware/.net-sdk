namespace DreamFactory.AddressBook.Models.Contact
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;

    public class ContactInfoViewModel
    {
        public string ReturnUrl { get; set; }
        public InfoType InfoType { get; set; }

        [Display(Name = "Contact info type")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        public ContactInfo ContactInfo { get; set; }
    }
}
