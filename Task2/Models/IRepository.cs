using System.Collections;
using System.Collections.Generic;

/*
 * A Repository interface can be used so that code does not have to care about implementation specific details
 * of the repository, if its SQL based, or if its saved to a file or in memory. This makes testing much easier,
 * since you can now test methods and classes that should save to a database, using a mock repository instead.
 */
namespace Task2.Models
{
    // Following the interface segregation principle, this could be separated into more granular interfaces.
    public interface IRepository<K,T>
    {
        void Create(T item);
        Contact Read(K key);
        bool HasItem(K key);
        K NextKey();
        void Update(K key, T item);
        void Delete(K key);
        
        /* Note: Ideally this should be a readonly collection, such the interface enforces that implementers
         * of this interface does not simply expose its internal collection mutably via this interface.
         * */
        Dictionary<K, T> ReadAll();
    }
}