namespace DreamFactory.AddressBook.Models
{
    using System.Collections.Generic;
    using DreamFactory.AddressBook.Models.Contact;

    public class ContactGroupViewModel
    {
        public ContactGroup ContactGroup { get; set; }
        public List<ContactContactGroupViewModel> Contacts { get; set; }
    }
}
