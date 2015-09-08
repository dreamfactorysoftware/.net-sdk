namespace DreamFactory.AddressBook.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;

    public class ContactGroup
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Name { get; set; }
    }
}