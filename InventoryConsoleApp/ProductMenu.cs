using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp
{
    class ProductMenu
    {
        private int _productNumber;
        List<Product> _productsTemp = new List<Product>();
        private int chooseMenu;

        public ProductMenu(int productNumber, List<Product> products)
        {
            _productsTemp = products;
            _productNumber = productNumber;
        }

        public void ShowProductInfo(int product)
        {
            Console.Clear();
            Console.WriteLine($"Product name is {_productsTemp[product]._name}\t" +
                              $"Product count is {_productsTemp[product]._count}\t" +
                              $"Product price is {_productsTemp[product]._price}\t" +
                              $"Product id is {_productsTemp[product]._id}");
        }

        public void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    chooseMenu++;
                    Console.SetCursorPosition(0,chooseMenu);
                    CheckKey();
                    break;
                case ConsoleKey.UpArrow:
                    chooseMenu--;
                    Console.SetCursorPosition(0,chooseMenu);
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

        public void MenuItem(int item)
        {
            switch (item)
            {
                case 0:
                    Console.WriteLine("Write count");
                    _productsTemp[_productNumber]._count -= Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    CheckKey();
                    break;
                case 1:

                    _productsTemp.RemoveAt(_productNumber);
                    break;
                case 2:
                    Console.WriteLine("Write count to add");
                    _productsTemp[_productNumber]._count += Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    CheckKey();
                    break;
                case 3:
                    Console.WriteLine("Write new price");
                    _productsTemp[_productNumber]._price = Int32.Parse(Console.ReadLine());
                    ShowProductInfo(_productNumber);
                    ShowMenu();
                    CheckKey();
                    break;
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("Delete some count of products\n" +
                              "Delete this product full\n" +
                              "Add some count product\n" +
                              "Change price\n" +
                              "CLICK BACKSPACE TO RETURN");

            chooseMenu = 0;
            Console.SetCursorPosition(0, chooseMenu);

            CheckKey();

        }

        public List<Product> GetNewProductList()
        {
            return _productsTemp;
        }
    }
}
