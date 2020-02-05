using System;
using Products;

namespace InventoryConsoleApp
{
    class Program
    {
        private static int _chooseItem = 0;
        private static readonly string[] _nameMenuItems = new string[] { "Add to inventory", "Show Inventory", "Show Basket", "Clear Basket" };

        static void Main(string[] args)
        {
            ShowMenu();
            CheckKey();
        }

        static void ShowMenu()
        {
            Console.Clear();

            for (int i = 0; i < _nameMenuItems.Length; i++)
            {
                if (_chooseItem == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"----->\t{_nameMenuItems[i]}");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.WriteLine($"\t{_nameMenuItems[i]}");
                }
            }
        }

        private static void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (_chooseItem < _nameMenuItems.Length - 1)
                    {
                        _chooseItem++;
                        ShowMenu();
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (_chooseItem > 0)
                    {
                        _chooseItem--;
                        ShowMenu();
                    }

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

       private static void MenuAction(int chooseItem)
        {
            switch (chooseItem)
            {
                case (int)MenuItems.AddToInventory:
                    Console.WriteLine("Write product name");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Write count of product");
                    int productCount;

                    while (!int.TryParse(Console.ReadLine(),out productCount))
                    {
                        Console.WriteLine("Write correct count");
                    }

                    Console.WriteLine("Write product price");
                    double productPrice;

                    while (!double.TryParse(Console.ReadLine(), out productPrice))
                    {
                        Console.WriteLine("Please, write correct price");
                    }

                    Product product = new Product(productName,productCount,productPrice);

                    Inventory.AddToInventory(product);
                    chooseItem = 0;
                    ShowMenu();

                    break;
                case (int)MenuItems.ShowInventory:
                    Inventory.ShowInventory();
                    chooseItem = 0;
                    ShowMenu();

                    break;
                case (int)MenuItems.ShowBasket:
                    Basket.ShowBasket();
                    chooseItem = 0;
                    ShowMenu();
                    
                    break;
                case (int)MenuItems.ClearBasket:
                    Basket.ClearBasket();
                    chooseItem = 0;
                    ShowMenu();

                    break;
            }
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
