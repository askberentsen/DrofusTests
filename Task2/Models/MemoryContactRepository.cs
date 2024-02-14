using System;
using System.Collections.Generic;

namespace Task2.Models
{
    public class MemoryContactRepository : IRepository<Contact>
    {
        private static MemoryContactRepository _singleton = null;

        public static MemoryContactRepository Singleton => _singleton ?? (_singleton = new MemoryContactRepository());

        private MemoryContactRepository()
        {
            // Fill repository
            Create(new Contact(
                1,
                "Ola",
                "Nordmann",
                "Norge.no",
                "Norsk patriot",
                "Norgegata 1905",
                "+47 2222 5555",
                new DateTime(1905, 6, 7)
                ));
            Create(new Contact(
                2,
                "Öla",
                "Svenskmann",
                "Sverige.se",
                "Svensk patriot",
                "Sverigegata 3",
                "+46 1 2345 6789",
                new DateTime(2000, 1, 1)
            ));
        }
        
        public Dictionary<long, Contact> Repository { get; } = new Dictionary<long, Contact>();

        public void Create(Contact contact)
        {
            //TODO: check that ID is unique
            Repository[contact.ID] = contact;
        }

        public Contact Read(long id)
        {
            return Repository[id];
        }

        public void Update(Contact contact)
        {
            // In memory. We *shouldn't* need to do anything, under the assumption that the contact instance wasn't cloned.
            Repository[contact.ID] = contact;
        }

        public void Delete(long id)
        {
            Repository.Remove(id);
        }

        public Dictionary<long, Contact> ReadAll()
        {
            return Repository;
        }
        
        //TODO: method for checking next available ID
    }
}