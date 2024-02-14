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
            vendingMachine.SetPrice("potato",2);
            Console.WriteLine(vendingMachine.GetPrice("potato"));
            vendingMachine.AddCredit(40);
            Console.WriteLine(vendingMachine.Credit);

            Ware ware = vendingMachine.Purchase("potato");
        }
    }

    internal class VendingMachine
    {
        // This should not be exposed without making this a backing field for a readonly dictionary.
        private Dictionary<string, int> WarePrices { get; set; } = new Dictionary<string, int>();
        public int Credit { get; private set; } = 0;

        public void AddCredit(int credit)
        {
            // A user should not be able to add a negative amount of credit
            if (this.Credit + credit > this.Credit)
            {
                this.Credit += credit;
            }
            else
            {
                throw new ArgumentException("Can't add credit such that the available credit is less than zero");
            }
        }

        public Ware Purchase(string wareName)
        {
            if ( HasEnoughCredit(wareName) )
            {
                return new Ware();
            }
            else
            {
                throw new InvalidOperationException("Not enough credits");
            }
        }

        public bool HasEnoughCredit(string wareName)
        {
            return this.Credit > this.WarePrices[wareName];
        }

        public int GetPrice(string wareName)
        {
            return WarePrices[wareName];
        }

        public void SetPrice(string wareName, int price)
        {
            WarePrices[wareName] = price;
        }
    }

    internal class Ware
    {
    }
}