namespace DreamFactory.AddressBook.Models.Contact
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public int Ordinal { get; set; }
        public int ContactId { get; set; }
        public string InfoType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
