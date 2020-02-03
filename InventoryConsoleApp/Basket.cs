using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConsoleApp
{
    class Basket
    {
        private static List<Product> basketProducts = new List<Product>();

        public static void ShowBasket()
        {
            Console.Clear();

            if (basketProducts.Count < 1)
            {
                Console.WriteLine("Basket is empty. Click any key to return");
                Console.ReadKey();

            }
            else
            {
                Console.Write($"The cost of everything in the basket: {GetCost()}\n");

                for (var i = 0; i < basketProducts.Count; i++)
                {
                    Product product = basketProducts[i];

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
            if (basketProducts.Count > 1)
            {
                for (int i = 0; i < basketProducts.Count; i++)
                {
                    Inventory.AddToInventory(basketProducts[i]);
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
            basketProducts.Clear();
        }

        public static void AddToBasket(Product product)
        {
            bool productExist = false;

            for (int i = 0; i < basketProducts.Count; i++)
            {
                if (product._id == basketProducts[i]._id)
                {
                    basketProducts[i]._count += product._count;
                    productExist = true;
                }
            }

            if(!productExist)
                basketProducts.Add(product);

            Console.WriteLine("Product in basket. Press any key to continue");
            Console.ReadKey();
        }


        private static double GetCost()
        {
            double cost = 0;

            foreach (var basketProduct in basketProducts)
            {
                cost += basketProduct._count * basketProduct._price;
            }

            return cost;
        }
    }
}
