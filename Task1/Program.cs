using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using Task1.Models;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            // Fill vending machine
            List<Ware> wares = new List<Ware>()
            {
                new Ware("Bing Soda", 25),
                new Ware("Pizza in a can", 90),
                new Ware("Grass", 5),
                new Ware("Mustard Soda", 25),
                new Ware("Salad", 35),
                new Ware("Turbocoke", 27),
                new Ware("Norvegia", 60),
                new Ware("6-up", 30),
                new Ware("Yacht", 7_000_000),
                new Ware("Packing Peanuts", 54),
            };

            foreach (Ware ware in wares)
            {
                vendingMachine.AddWare(ware);
            }
            vendingMachine.SetPrice("Diamonds",16);

            Console.WriteLine(
                "Welcome to the Vending Machine console interface!\n" +
                "Available commands:\n" +
                "list - lists the price of items\n" +
                "insert <integer> - insert an amount of money into the vending machine\n" +
                "recall - cancel, and retrieve inserted money\n" +
                "order <item name>"
                );

            string[] input;
            string command = null;
            string parameter;

            do
            {
                Console.Write("> ");
                input = Console.ReadLine()?.ToLower().Split(' ');
                command = input[0];
                parameter = input.Length > 1 ? input[1] : "";
                
            } while (command != "exit");
        }
    }
}