namespace DreamFactory.AddressBook.Models.Entities
{
    using Newtonsoft.Json;

    public class ContactContactGroup
    {
        public int? Id { get; set; }

        public int? ContactId { get; set; }

        public int? ContactGroupId { get; set; }

        [JsonProperty(PropertyName = "contact_by_contact_id")]
        public Contact Contact { get; set; }

        [JsonProperty(PropertyName = "contact_group_by_contact_group_id")]
        public ContactGroup ContactGroup { get; set; }

    }
}
