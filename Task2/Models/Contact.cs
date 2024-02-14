using System;

namespace Task2.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Workplace { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        // Phone numbers cannot be treated as numbers, and therefore should not be implemented as a numeric type
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }

        public Contact()
        {
        }

        public Contact(string firstName, string lastName, string workplace, string jobTitle, string address,
            string phoneNumber, DateTime birthday)
        {
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