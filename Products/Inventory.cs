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
            if (!IsProductExists(product, out Guid id))
            {
                _products.Add(product);
            }
            else
            {
                foreach (var prod in _products)
                {
                    if (prod._id == id)
                        prod._count += product._count;
                }
            }
        }

        private static bool IsProductExists(Product product, out Guid id)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (product._name == _products[i]._name && product._price == _products[i]._price)
                {
                    id = _products[i]._id;
                    return true;
                }
            }
            return false;
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

                case ConsoleKey.Backspace:
                    break;

                case ConsoleKey.Enter:
                    ProductMenu productMenu = new ProductMenu(_productChoose - 1, _products);
                    productMenu.ShowMenu();

                    _products = productMenu.GetNewProductList();

                    _productChoose = 1;
                    ShowInventory();
                    break;
            }
        }

        private static void MakeChoise(ConsoleKey key)
        {
            if (_productChoose < _products.Count && key == ConsoleKey.DownArrow)
            {
                _productChoose++;
                ShowInventory();
            }

            else if (_productChoose > 1 && key == ConsoleKey.UpArrow)
            {
                _productChoose--;
                ShowInventory();
            }
            CheckKey();
        }

        public static void ShowInventory()
        {
            Console.Clear();

            if (_products.Count > 0)
            {
                Console.WriteLine(Messages.HelpersMessages.backSpaceToReturn);

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

                Console.WriteLine(Messages.HelpersMessages.backSpaceToReturn);
                CheckKey();
            }
            else
            {
                Console.WriteLine(Messages.HelpersMessages.emptyInventory);
                Console.ReadKey();
            }
        }
    }
}
