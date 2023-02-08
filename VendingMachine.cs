using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SodaVendingMachine
{
    internal class VendingMachine  //could make a StockWithSoda() method
    {
        private int _balance;
        private Soda[] _stock;

        public VendingMachine(int balance, Soda[] stock)
        {
            _balance = balance;
            _stock = stock;
        }

        public void ShowStock()
        {
            Console.WriteLine("Available sodas:");
            int index = 0;
            foreach (var soda in _stock)
            {
                Console.WriteLine($"[{index+1}] " + soda.Name + soda.Cost.ToString().PadLeft(15 - soda.Name.Length) + 
                    " kr (In stock: " + soda.InStock.ToString().PadLeft(2, '0') + ")");
                index++;
            }
            Console.WriteLine();
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current balance: {_balance}");
        }

        public void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("[I] Insert money\n[W] Withdraw money\nTo choose a soda, type its corresponding ID.");
            string input = Console.ReadLine().ToUpper();

            if (input == "I") ShowMoneyInput();
            else if (input == "W")
            {
                Console.Clear();
                Console.WriteLine($"You withdrew {_balance} kr.");
                Console.WriteLine();
                _balance = 0;
            }
            else if (input == "1" || input == "2" || input == "3" || input == "4") BuySoda(Convert.ToInt32(input));
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
            }
        }

        public bool ValidInputCheck(string input, string[] validInputs)
        {
            if (validInputs.Contains(input)) return true;
            else return false;
        }

        public void ShowMoneyInput()
        {
            string input;
            bool validInput;
            Console.Clear();
            while (true)
            {
                ShowBalance();
                string[] validInputs = { "1", "5", "10", "20", "B" };
                Console.WriteLine("How much do you wish to insert?\n[1]kr\n[5]kr\n[10]kr\n[20]kr\n[B] Back");
                input = Console.ReadLine().ToUpper();
                validInput = ValidInputCheck(input, validInputs);

                if (input != "B" && validInput == true)
                {
                    Console.Clear();
                    _balance += Convert.ToInt32(input);
                }
                else if (input == "B")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        public void BuySoda(int input)
        {
            Console.Clear();
            var choice = _stock[input-1];
            if (_balance >= choice.Cost && choice.InStock != 0)
            {
                choice.InStock -= 1;
                _balance -= choice.Cost;
                Console.WriteLine($"You bought: {choice.Name}");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Out of stock.");
                Console.WriteLine();
            }

        }
    }
}
