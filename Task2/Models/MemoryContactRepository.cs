using System;
using System.Collections.Generic;

namespace Task2.Models
{
    public class MemoryContactRepository : IRepository<long,Contact>
    {
        private static MemoryContactRepository _singleton = null;

        public static MemoryContactRepository Singleton => _singleton ?? (_singleton = new MemoryContactRepository());

        private MemoryContactRepository()
        {
            // Fill repository
            Create(new Contact(
                "Ola",
                "Nordmann",
                "Norge.no",
                "Norsk patriot",
                "Norgegata 1905",
                "+47 2222 5555",
                new DateTime(1905, 6, 7)
                ));
            Create(new Contact(
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
        private long _nextId { get; set; } = 1;

        public void Create(Contact contact)
        {
            Repository[NextKey()] = contact;
            _nextId++;
        }

        public Contact Read(long id)
        {
            return Repository[id];
        }

        public bool HasItem(long id)
        {
            return Repository.ContainsKey(id);
        }

        // Ideally, this should not be sequential, as it is weak against scraping.
        public long NextKey()
        {
            return _nextId;
        }

        public void Update(long id, Contact contact)
        {
            // In memory. We *shouldn't* need to do anything, under the assumption that the contact instance wasn't cloned.
            Repository[id] = contact;
        }

        public void Delete(long id)
        {
            Repository.Remove(id);
        }

        public Dictionary<long, Contact> ReadAll()
        {
            return Repository;
        }
    }
}