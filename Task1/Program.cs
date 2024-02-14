using System;
using System.Collections.ObjectModel;
using Task1.Models;

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
}