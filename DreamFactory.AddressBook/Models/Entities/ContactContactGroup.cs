namespace DreamFactory.AddressBook.Models.Entities
{
    using Newtonsoft.Json;

    public class ContactContactGroup
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "contact_id")]
        public int? ContactId { get; set; }

        [JsonProperty(PropertyName = "contact_group_id")]
        public int? ContactGroupId { get; set; }

        [JsonProperty(PropertyName = "contact_by_contact_id")]
        public Contact Contact { get; set; }

        [JsonProperty(PropertyName = "contact_group_by_contact_group_id")]
        public ContactGroup ContactGroup { get; set; }

    }
}
