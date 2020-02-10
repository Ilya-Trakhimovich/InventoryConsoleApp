using System;
using Products;

namespace InventoryConsoleApp
{
    class Program
    {
        private static int _chooseItem = 0;

        static void Main(string[] args)
        {
            ShowMenu();
            CheckKey();
        }

        static void ShowMenu()
        {
            Console.Clear();

            for (int i = 0; i < Messages.MenuItems._mainMenuItems.Length; i++)
            {
                if (_chooseItem == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"----->\t{Messages.MenuItems._mainMenuItems[i]}");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.WriteLine($"\t{Messages.MenuItems._mainMenuItems[i]}");
                }
            }
        }

        private static void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                 MakeChoise(ConsoleKey.DownArrow);
                 break;

                case ConsoleKey.UpArrow:
                MakeChoise(ConsoleKey.UpArrow);
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    MenuAction(_chooseItem);
                    break;

                default:
                    break;
            }
            CheckKey();
        }

        private static void MakeChoise(ConsoleKey key)
        {
            if (_chooseItem < Messages.MenuItems._mainMenuItems.Length - 1 && key == ConsoleKey.DownArrow)
            {
                _chooseItem++;
                ShowMenu();
            }
            else if (_chooseItem > 0 && key == ConsoleKey.UpArrow)
            {
                _chooseItem--;
                ShowMenu();
            }
        }

       private static void MenuAction(int chooseItem)
        {
            switch ((MenuItems)chooseItem)
            {
                case MenuItems.AddToInventory:
                    Inventory.AddToInventory(MakeSomeProduct());
                    break;
                case MenuItems.ShowInventory:
                    Inventory.ShowInventory();
                    break;
                case MenuItems.ShowBasket:
                    Basket.ShowBasket();
                    break;
                case MenuItems.ClearBasket:
                    Basket.ClearBasket();
                    break;
            }
            ShowMenu();
        }

       private static Product MakeSomeProduct()
       {
           Console.WriteLine("Write product name");
           string productName = Console.ReadLine();

           Console.WriteLine("Write count of product");
           int productCount;

           while (!int.TryParse(Console.ReadLine(), out productCount))
           {
               Console.WriteLine(Messages.ExceptionMessages.countError);
           }

           Console.WriteLine("Write product price");
           double productPrice;

           while (!double.TryParse(Console.ReadLine(), out productPrice))
           {
               Console.WriteLine(Messages.ExceptionMessages.priceError);
           }

           Product product = new Product(productName, productCount, productPrice);

            return product;
       }

        private enum MenuItems
        {
            AddToInventory,
            ShowInventory,
            ShowBasket,
            ClearBasket
        }
    }
}
