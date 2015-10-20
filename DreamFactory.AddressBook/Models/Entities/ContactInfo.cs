namespace DreamFactory.AddressBook.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;
    using Newtonsoft.Json;

    public class ContactInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "ordinal")]
        public int? Ordinal { get; set; }

        [JsonProperty(PropertyName = "contact_id")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        public int? ContactId { get; set; }

        [JsonProperty(PropertyName = "info_type")]
        public string InfoType { get; set; }

        [JsonProperty(PropertyName = "phone")]
        [Display(Name = "Phone")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(32, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Display(Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "address")]
        [Display(Name = "Address")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "city")]
        [Display(Name = "City")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        [Display(Name = "State")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        [Display(Name = "Zip")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(16, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "country")]
        [Display(Name = "Country")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "contact_by_contact_id")]
        public Contact Contact { get; set; }
    }
}
