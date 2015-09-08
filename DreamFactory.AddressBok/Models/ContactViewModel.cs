namespace DreamFactory.AddressBook.Models
{
    using System.Collections.Generic;
    using DreamFactory.AddressBook.Models.Contact;

    public class ContactViewModel
    {
        public int? GroupId { get; set; }
        public Contact.Contact Contact { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
