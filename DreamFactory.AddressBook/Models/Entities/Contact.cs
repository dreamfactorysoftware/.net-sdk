namespace DreamFactory.AddressBook.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;
    using Newtonsoft.Json;

    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        [Display(Name = "First name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        [Display(Name = "Last name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(40, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "twitter")]
        [Display(Name = "Twitter handle")]
        [MaxLength(18, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Twitter { get; set; }

        [JsonProperty(PropertyName = "skype")]
        [Display(Name = "Skype name")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Skype { get; set; }

        [JsonProperty(PropertyName = "notes")]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "contact_info_by_contact_id")]
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
