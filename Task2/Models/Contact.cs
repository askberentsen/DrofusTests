using System;

namespace Task2.Models
{
    public class Contact
    {
        public readonly long ID;

        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string Workplace { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        // Phone numbers cannot be treated as numbers, and therefore should not be implemented as a numeric type
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        
        public Contact(long id)
        {
            ID = id;
        }
    }
}