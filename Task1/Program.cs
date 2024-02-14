using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.AddWare(new Ware("potato"));
            Console.WriteLine(vendingMachine.GetPrice("potato"));
            vendingMachine.AddCredit(40);
            Console.WriteLine(vendingMachine.Credit);

            Tuple<Ware, uint> purchase = vendingMachine.Purchase("potato");
            Ware ware = purchase.Item1;
            uint change = purchase.Item2;
            Console.WriteLine(ware.Name);
            Console.WriteLine(change);
            Console.WriteLine(vendingMachine.Credit);
        }
    }

    internal class VendingMachine
    {
        // This should not be exposed without making this a backing field for a readonly dictionary.
        private Dictionary<string, uint> WarePrices { get; set; } = new Dictionary<string, uint>();
        
        // Vending machines are filled from the back, so the oldest wares are output first.
        private Dictionary<string, Queue<Ware>> Stock { get; } = new Dictionary<string, Queue<Ware>>();
        public uint Credit { get; private set; } = 0;

        public void AddCredit(uint credit)
        {
            // A user should not be able to add a negative amount of credit
            if (this.Credit + credit < this.Credit) throw new OverflowException(nameof(credit));
            this.Credit += credit;
        }

        public Tuple<Ware, uint> Purchase(string wareName)
        {
            if (!HasEnoughCredit(wareName)) throw new InvalidOperationException("Not enough credits");
            if (!HasWare(wareName)) throw new InvalidOperationException("Out of stock");
            
            Ware ware = Stock[wareName].Dequeue();
            uint change = Credit - WarePrices[wareName];
            Credit = 0;
            
            return new Tuple<Ware, uint>(ware, change);
        }

        private bool HasEnoughCredit(string wareName)
        {
            return this.Credit > this.WarePrices[wareName];
        }

        private bool HasWare(string wareName)
        {
            return true;
        }

        public uint GetPrice(string wareName)
        {
            return WarePrices[wareName];
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
                WarePrices[ware.Name] = ware.DefaultPrice;
            }
        }
    }

    internal class Ware
    {
        public string Name { get; }
        public uint DefaultPrice { get; } = 10;

        public Ware(string name)
        {
            this.Name = name;
        }

        public Ware(string name, uint defaultPrice)
        {
            Name = name;
            DefaultPrice = defaultPrice;
        }
    }
}