namespace DreamFactory.AddressBook.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DreamFactory.AddressBook.Properties;
    using Newtonsoft.Json;

    public class ContactGroup
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Display(Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessage = null)]
        [MaxLength(128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessage = null)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "contact_by_contact_group_relationship")]
        public List<Contact> Contacts { get; set; } 
    }
}