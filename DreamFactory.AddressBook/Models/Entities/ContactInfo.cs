namespace DreamFactory.AddressBook.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;
    using Newtonsoft.Json;

    public class ContactInfo
    {
        public int? Id { get; set; }

        public int? Ordinal { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        public int? ContactId { get; set; }

        public string InfoType { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(32, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string State { get; set; }

        [Display(Name = "Zip")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(16, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Zip { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "contact_by_contact_id")]
        public Contact Contact { get; set; }
    }
}
