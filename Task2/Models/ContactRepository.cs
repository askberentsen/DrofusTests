using System.Collections;
using System.Collections.Generic;

namespace Task2.Models
{
    // Following the interface segregation principle, this could be separated into more granular interfaces.
    public interface IContactRepository
    {
        void Create(Contact contact);
        Contact Read(long id);
        void Update(Contact contact);
        void Delete(long id);
        
        /* Note: Ideally this should be a readonly collection, such the interface enforces that implementers
         * of this interface does not simply expose its internal collection mutably via this interface.
         * */
        Dictionary<long, Contact> ReadAll();
    }
}