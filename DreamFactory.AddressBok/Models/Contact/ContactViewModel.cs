namespace DreamFactory.AddressBook.Models.Contact
{
    using System.Collections.Generic;

    public class ContactViewModel
    {
        public int? GroupId { get; set; }
        public Contact Contact { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
