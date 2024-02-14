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
            Dictionary<string, uint> wares = new Dictionary<string, uint>()
            {
                {"Bing Soda", 25},
                {"Pizza in a can", 90},
                {"Grass", 5},
                {"Mustard Soda", 25},
                {"Salad", 35},
                {"Turbocoke", 27},
                {"Norvegia", 60},
                {"6-up", 30},
                {"Yacht", 7_000_000},
                {"Packing Peanuts", 54},
            };

            foreach (KeyValuePair<string, uint> keyValuePair in wares)
            {
                vendingMachine.SetPrice(keyValuePair.Key, keyValuePair.Value);
                vendingMachine.AddWare(new Ware(keyValuePair.Key));
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