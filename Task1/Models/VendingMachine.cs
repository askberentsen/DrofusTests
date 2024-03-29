using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Models
{
    public class VendingMachine
    {
        // This should not be exposed without making this a backing field for a readonly dictionary.
        private Dictionary<string, uint> WarePrices { get; set; } = new Dictionary<string, uint>();
        
        // Vending machines are filled from the back, so the oldest wares are output first.
        private Dictionary<string, Queue<Ware>> Stock { get; } = new Dictionary<string, Queue<Ware>>();
        public uint Credit { get; private set; } = 0;

        private bool HasEnoughCredit(string wareName)
        {
            return this.Credit > this.WarePrices[wareName];
        }

        private bool HasWare(string wareName)
        {
            return WarePrices.ContainsKey(wareName);
        }

        public uint GetPrice(string wareName)
        {
            return WarePrices[wareName];
        }

        /* Give access to the prices, without giving access to modify the collection.
         * This is better implemented using readonly/immutable classes, but my current environment does not have
         * those classes, so this is an ad hoc solution.
         */
        public IEnumerable<KeyValuePair<string, uint>> GetPrices()
        {
            return WarePrices.AsEnumerable();
        }

        public void SetPrice(string wareName, uint price)
        {
            WarePrices[wareName] = price;
        }

        public void AddWare(Ware ware)
        {
            if ( !Stock.ContainsKey(ware.Name) ) Stock[ware.Name] = new Queue<Ware>();
            
            Stock[ware.Name].Enqueue(new Ware(ware.Name));

            if ( !WarePrices.ContainsKey(ware.Name) )
            {
                // If someone forgets to set the price, its better if the price is set to the maximum instead of free.
                WarePrices[ware.Name] = uint.MaxValue;
            }
        }
        
        public void AddCredit(uint credit)
        {
            // A user should not be able to add a negative amount of credit
            if (!CanAddCredit(credit)) throw new OverflowException(nameof(credit));
            this.Credit += credit;
        }

        private bool CanAddCredit(uint credit)
        {
            return this.Credit + credit > this.Credit;
        }

        public uint Recall()
        {
            uint creditsBack = Credit;
            Credit = 0;
            return creditsBack;
        }
        
        public Tuple<Ware, uint> Purchase(string wareName)
        {
            if (!HasWare(wareName)) throw new InvalidOperationException("Unrecognized item");
            if (!IsInStock(wareName)) throw new InvalidOperationException("Out of stock");
            /* because of uints, the change calculation is written twice, one for negative amounts,
             * and one for positive amounts */
            if (!HasEnoughCredit(wareName)) throw new InvalidOperationException(
                $"Not enough credit, need {WarePrices[wareName] - Credit} more"
                );
            
            Ware ware = Stock[wareName].Dequeue();
            uint change = Credit - WarePrices[wareName];
            Credit = 0;
            
            return new Tuple<Ware, uint>(ware, change);
        }

        private bool IsInStock(string wareName)
        {
            // Returns false if there is no queue, and the queue is empty
            return Stock[wareName]?.Count > 0;
        }
    }
}