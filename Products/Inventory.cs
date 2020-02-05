using System;
using System.Collections.Generic;

namespace Products
{
    public static class Inventory
    {
        private static List<Product> _products = new List<Product>();
        private static int _productChoose = 1;

        public static void AddToInventory(Product product)
        {
            if (!ProductExist(product, out Guid id))
            {
                _products.Add(product);
            }
            else
            {
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i]._id == id)
                        _products[i]._count += product._count;
                }
            }
        }

        private static bool ProductExist(Product product, out Guid id)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (product._name == _products[i]._name && product._price == _products[i]._price)
                {
                    id = _products[i]._id;
                    return true;
                }
            }

            id = Guid.Empty;
            return false;
        }

        private static void CheckKey()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (_productChoose < _products.Count)
                    {
                        _productChoose++;
                        ShowInventory();
                    }

                    CheckKey();

                    break;

                case ConsoleKey.UpArrow:
                    if (_productChoose > 1)
                    {
                        _productChoose--;
                        ShowInventory();
                    }

                    CheckKey();
                    break;

                case ConsoleKey.Backspace:
                    break;

                case ConsoleKey.Enter:
                    ProductMenu productMenu = new ProductMenu(_productChoose - 1, _products);
                    productMenu.ShowProductInfo(_productChoose - 1);
                    productMenu.ShowMenu();

                    _products = productMenu.GetNewProductList();

                    _productChoose = 1;
                    ShowInventory();
                    break;
            }
        }

        public static void ShowInventory()
        {
            Console.Clear();

            if (_products.Count > 0)
            {
                Console.WriteLine("Press BackSpace to return in menu");

                for (var i = 0; i < _products.Count; i++)
                {
                    Product product = _products[i];

                    if (_productChoose - 1 == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"---->\tProduct name is {product._name}\t" +
                                          $"Product count is {product._count}\t" +
                                          $"Product price is {product._price}\t" +
                                          $"Product id is {product._id}");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.WriteLine($"Product name is {product._name}\t" +
                                          $"Product count is {product._count}\t" +
                                          $"Product price is {product._price}\t" +
                                          $"Product id is {product._id}");
                    }
                }

                Console.WriteLine("Press BackSpace to return in menu");
                CheckKey();
            }
            else
            {
                Console.WriteLine("Inventory is empty. Press any key to back in main menu");
                Console.ReadKey();
            }
        }
    }
}
