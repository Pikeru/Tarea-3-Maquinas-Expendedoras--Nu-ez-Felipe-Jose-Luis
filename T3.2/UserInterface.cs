using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class UserInterface
    {
        //Fields
        private VendingMachine snacks;
        private VendingMachine drinks;

        public enum Menu
        {
            SnackMenu = 1,
            DrinkMenu = 2,
            Exit = 3,
        }
        public enum Options
        {
            EnterCash = 1,
            SelectProduct = 2,
            Refund = 3,
            Exit = 4,
        }

        //Constructor

        public UserInterface()
        {
            snacks = new VendingMachine("snacks");
            drinks = new VendingMachine("drinks");
        }

        //Methods

        public void Selection(VendingMachine machine, int option)
        {
            Console.Clear();
            switch (option)
            {
                case (int)Options.EnterCash:
                    machine.EnterCash();
                    break;
                case (int)Options.SelectProduct:
                    machine.SelectProduct();
                    break;
                case (int)Options.Refund:
                    machine.Refund();
                    break;
                case (int)Options.Exit:
                    break;
            }
        }
        public void SelectMenu(int MenuOption)
        {
            int selection = 0;
            Console.Clear();
            switch (MenuOption)
            {
                case (int)Menu.SnackMenu:
                    //Selection(snacks, selection());
                    while (selection != (int)Options.Exit)
                    {
                        selection = MachineMenu(snacks);
                        Selection(snacks, selection);
                    }
                    break;
                case (int)Menu.DrinkMenu:
                    while (selection != (int)Options.Exit)
                    {
                        selection = MachineMenu(drinks);
                        Selection(drinks, selection);
                    }
                    break;
                case (int)Menu.Exit:
                    Environment.Exit(1);
                    break;
            }
        }
        public void Start()
        {
            int selection = 0;
            while (selection != (int)Menu.Exit)
            {
                Console.WriteLine("\tWelcome to the vending machines!");
                Console.WriteLine("Select a option!");
                Console.WriteLine("1.-Snacks machine.");
                Console.WriteLine("2.-Drinks machine.");
                Console.WriteLine("3.-Exit.");
                selection = Convert.ToInt32(Console.ReadLine());
                SelectMenu(selection);
            }
        }
        public int MachineMenu(VendingMachine current)
        {
            current.ShowProduct();
            Console.WriteLine("Your credit is {0}", current.Credit);
            Console.WriteLine("Select a option");
            Console.WriteLine("1.-Deposit money.");
            Console.WriteLine("2.-Select a product.");
            Console.WriteLine("3.-Refund.");
            Console.WriteLine("4.-Exit.");
            int selection = Convert.ToInt32(Console.ReadLine());
            return selection;
        }

    }
}
