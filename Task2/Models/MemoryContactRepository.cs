using System;
using System.Collections.Generic;

namespace Task2.Models
{
    public class MemoryContactRepository : IRepository<Contact>
    {
        public Dictionary<long, Contact> Repository { get; } = new Dictionary<long, Contact>();

        public void Create(Contact contact)
        {
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
    }
}