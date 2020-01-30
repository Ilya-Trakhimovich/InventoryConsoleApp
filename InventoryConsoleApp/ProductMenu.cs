using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp
{
    class ProductMenu
    {
        private int _productNumber;
        static string[] nameMenuItems = new string[] { "Delete some count of products", "Delete this product full", "Add some count product", "Change price" };
        List<Product> _productsTemp = new List<Product>();
        private int chooseMenu;

        public ProductMenu(int productNumber, List<Product> products)
        {
            _productsTemp = products;
            _productNumber = productNumber;
            chooseMenu = 1;
        }

        public void ShowProductInfo(int product)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Product name is {_productsTemp[product]._name}\t" +
                              $"Product count is {_productsTemp[product]._count}\t" +
                              $"Product price is {_productsTemp[product]._price}\t" +
                              $"Product id is {_productsTemp[product]._id}");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (chooseMenu < nameMenuItems.Length)
                    {
                        chooseMenu++;
                        ShowProductInfo(_productNumber);
                        ShowMenu();
                    }

                    CheckKey();
                    break;
                case ConsoleKey.UpArrow:
                    if (chooseMenu > 1)
                    {
                        chooseMenu--;
                        ShowProductInfo(_productNumber);
                        ShowMenu();
                    }

                    CheckKey();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    MenuItem(chooseMenu-1);
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    break;
            }
        }

        private void MenuItem(int item)
        {
            switch (item)
            {
                case 0:
                    Console.WriteLine("Write count");
                    _productsTemp[_productNumber]._count -= Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    break;
                case 1:

                    _productsTemp.RemoveAt(_productNumber);
                    break;
                case 2:
                    Console.WriteLine("Write count to add");
                    _productsTemp[_productNumber]._count += Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    break;
                case 3:
                    Console.WriteLine("Write new price");
                    _productsTemp[_productNumber]._price = Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    break;
            }
        }

        public void ShowMenu()
        {
            for (int i = 0; i < nameMenuItems.Length; i++)
            {
                if (chooseMenu - 1 == i)
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
            Console.WriteLine("PRESS BACKSPACE TO RETURN");
            CheckKey();
        }

        public List<Product> GetNewProductList()
        {
            return _productsTemp;
        }
    }
}
