using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Wares.Add("potato",2);
            Console.WriteLine(vendingMachine.Wares["potato"]);
            vendingMachine.AddCredit(40);
            Console.WriteLine(vendingMachine.Credit);
        }
    }

    internal class VendingMachine
    {
        public Dictionary<string, int> Wares { get; private set; } = new Dictionary<string, int>();
        public int Credit { get; private set; } = 0;

        public void AddCredit(int credit)
        {
            if (credit >= 0)
            {
                this.Credit += credit;
            }
        }
    }
}