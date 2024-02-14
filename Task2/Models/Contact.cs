using System;

namespace Task2.Models
{
    public class Contact
    {
        public readonly long ID;

        public string FirstName { get; set; }
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

        public Contact(long id, string firstName, string lastName, string workplace, string jobTitle, string address,
            string phoneNumber, DateTime birthday)
        {
            ID = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Workplace = workplace ?? throw new ArgumentNullException(nameof(workplace));
            JobTitle = jobTitle ?? throw new ArgumentNullException(nameof(jobTitle));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Birthday = birthday;
        }
    }
}