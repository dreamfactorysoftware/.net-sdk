namespace DreamFactory.AddressBook.Models
{
    using System.Collections.Generic;
    using DreamFactory.AddressBook.Models.Entities;

    public class ContactGroupViewModel
    {
        public ContactGroup ContactGroup { get; set; }
        public List<ContactContactGroupViewModel> Contacts { get; set; }
    }
}
