using System;
using System.Collections.Generic;


namespace InventoryConsoleApp
{
    static class Inventory
    {
        private static List<Product> products = new List<Product>();
        private static int productChoose = 1;

        public static void AddToInventory(Product product)
        {
            if (!ProductExist(product, out Guid id))
            {
                products.Add(product);
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i]._id == id)
                        products[i]._count += product._count;
                }
            }
        }

        public static bool ProductExist(Product product,out Guid id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (product._name == products[i]._name && product._price == products[i]._price)
                {
                    id = products[i]._id;
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
                    productChoose++;
                    Console.SetCursorPosition(0,productChoose);
                    CheckKey();
                    break;

                case ConsoleKey.UpArrow:
                    productChoose--;
                    Console.SetCursorPosition(0,productChoose);
                    CheckKey();
                    break;

                case ConsoleKey.Backspace:
                    break;

                case ConsoleKey.Enter:
                    ProductMenu productMenu = new ProductMenu(productChoose - 1,products);
                    productMenu.ShowProductInfo(productChoose - 1);
                    productMenu.ShowMenu();
                    products = productMenu.GetNewProductList();
                    ShowInventory();
                    //    ProductMenu(productChoose-1);
                    break;
            }
        }

        public static void ShowInventory()
        {
            Console.WriteLine("Press BackSpace to return in menu");

            foreach (Product product in products)
            {
                Console.WriteLine($"Product name is {product._name}\t" +
                                  $"Product count is {product._count}\t" +
                                  $"Product price is {product._price}\t" +
                                  $"Product id is {product._id}");
            }

            Console.WriteLine("Press BackSpace to return in menu");
            Console.SetCursorPosition(0,productChoose);
            CheckKey();
        }
    }
}
