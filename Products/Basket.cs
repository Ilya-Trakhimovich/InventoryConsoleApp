using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    public class Basket
    {
        private static List<Product> _basketProducts = new List<Product>();

        public static void ShowBasket()
        {
            Console.Clear();

            if (_basketProducts.Count < 1)
            {
                Console.WriteLine(Messages.HelpersMessages.emptyBasket);
                Console.ReadKey();

            }
            else
            {
                Console.Write($"The cost of everything in the basket: {GetCost()}\n");

                foreach (var product in _basketProducts)
                {
                    Console.WriteLine($"Product name is {product._name}\t" +
                                      $"Product count is {product._count}\t" +
                                      $"Product price is {product._price}\t" +
                                      $"Product id is {product._id}");
                }

                Console.WriteLine("Press any key to return in menu");
                Console.ReadKey();
            }
        }

        public static void ClearBasket()
        {
            if (_basketProducts.Count > 1)
            {
                foreach (var product in _basketProducts)
                {
                    Inventory.AddToInventory(product);
                }

                Console.WriteLine("Basket is clear.\n" +
                                  "All products return in inventory\n" +
                                  "Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Basket is already clear. Press any key to continue");
                Console.ReadKey();
            }
            _basketProducts.Clear();
        }

        public static void AddToBasket(Product product)
        {
            bool isProductExists = false;

            foreach (var prod in _basketProducts)
            {
                if (prod._id == product._id)
                {
                    prod._count += product._count;
                    isProductExists = true;
                    Console.WriteLine(Messages.HelpersMessages.productInBasket);
                }
            }

            if (!isProductExists)
            {
                _basketProducts.Add(product);
                Console.WriteLine(Messages.HelpersMessages.productInBasket);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static double GetCost() =>_basketProducts.Select(product => product._count * product._price).Sum();
    }
}
