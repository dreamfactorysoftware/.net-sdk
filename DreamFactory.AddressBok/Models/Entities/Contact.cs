namespace DreamFactory.AddressBook.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;

    public class Contact
    {
        public int? Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Twitter handle")]
        [MaxLength(18, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Twitter { get; set; }

        [Display(Name = "Skype name")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Skype { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
