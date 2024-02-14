﻿using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.List.Add("potato",2);
            Console.WriteLine(vendingMachine.List["potato"]);
        }
    }

    internal class VendingMachine
    {
        public VendingMachine()
        {
            List = new Dictionary<string, int>();
        }

        public Dictionary<string, int> List { get; internal set; }
    }
}