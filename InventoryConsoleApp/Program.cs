using System;

namespace InventoryConsoleApp
{
    class Program
    {
        private static int chooseItem = 0;

        static void Main(string[] args)
        {
            
            ShowMenu();
            CheckKey();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"{MenuItems.AddToInventory}\n" +
                              $"{MenuItems.ShowInventory}");
            chooseItem = 0;
            Console.SetCursorPosition(0,chooseItem);
        }

        static void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    chooseItem++;
                    Console.SetCursorPosition(0,chooseItem);
                    break;
                case ConsoleKey.UpArrow:
                    chooseItem--;
                    Console.SetCursorPosition(0,chooseItem);
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
                    ShowMenu();

                    break;
                case (int)MenuItems.ShowInventory:
                    Inventory.ShowInventory();
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
