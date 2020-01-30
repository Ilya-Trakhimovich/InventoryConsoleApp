using System;
using System.Dynamic;

namespace InventoryConsoleApp
{
    class Program
    {
        private static int chooseItem = 0;
        static string[] nameMenuItems = new string[] { "Add to inventory", "Show Inventory" };

        static void Main(string[] args)
        {
            
            ShowMenu();
            CheckKey();
        }

        static void ShowMenu()
        {
            Console.Clear();
            for (int i = 0; i < nameMenuItems.Length; i++)
            {
                if (chooseItem == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"----->\t{nameMenuItems[i]}");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.WriteLine($"\t{nameMenuItems[i]}");
                }
            }
        }

        static void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (chooseItem < nameMenuItems.Length - 1)
                    {
                        chooseItem++;
                        ShowMenu();
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (chooseItem > 0)
                    {
                        chooseItem--;
                        ShowMenu();
                    }

                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    MenuAction(chooseItem);
                    break;
            }
            CheckKey();
        }

       static void MenuAction(int chooseItem)
        {
            switch (chooseItem)
            {
                case (int)MenuItems.AddToInventory:
                    Console.WriteLine("Write product name");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Write count of product");
                    int productCount = Int32.Parse(Console.ReadLine()); // check on "is digit"

                    Console.WriteLine("Write product price");
                    double productPrice = Double.Parse(Console.ReadLine());

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
            }
        }

        enum MenuItems
        {
            AddToInventory,
            ShowInventory
        }
    }
}
