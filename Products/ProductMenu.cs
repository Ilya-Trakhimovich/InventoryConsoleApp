using System;
using System.Collections.Generic;


namespace Products
{
    class ProductMenu
    {
        private int _productNumber;

        private List<Product> _productsTemp = new List<Product>();
        private int _chooseMenu;

        private enum ProductMenuItems
        {
            RemoveCountProducts,
            RemoveProduct,
            AddCountProduct,
            ChangePrice,
            BasketAdd
        }

        public ProductMenu(int productNumber, List<Product> products)
        {
            _productsTemp = products;
            _productNumber = productNumber;
            _chooseMenu = 1;
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
                    MakeChoise(ConsoleKey.DownArrow);
                    break;
                case ConsoleKey.UpArrow:
                    MakeChoise(ConsoleKey.UpArrow);
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    MenuItem(_chooseMenu-1);
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    break;
            }
        }

        private void MakeChoise(ConsoleKey key)
        {
            if (_chooseMenu < Messages.MenuItems._productMenuItems.Length && key == ConsoleKey.DownArrow)
            {
                _chooseMenu++;
                ShowMenu();
            }
            else
            {
                CheckKey();
            }

            if (_chooseMenu > 1 && key == ConsoleKey.UpArrow)
            {
                _chooseMenu--;
                ShowMenu();
            }
            else
            {
                CheckKey();
            }
        }

        private void MenuItem(int item)
        {
            switch ((ProductMenuItems)item)
            {
                case ProductMenuItems.RemoveCountProducts:
                    RemoveCountProduct();
                    break;
                case ProductMenuItems.RemoveProduct:
                    _productsTemp.RemoveAt(_productNumber);
                    break;
                case ProductMenuItems.AddCountProduct:
                    AddCountProduct();
                    break;
                case ProductMenuItems.ChangePrice:
                    ChangePriceProduct();
                    break;
                case ProductMenuItems.BasketAdd:
                    AddToBasket();
                    break;
            }
        }

        private void AddToBasket()
        {
            int tempCount = 0;
            Console.WriteLine(Messages.HelpersMessages.countAdd);

            while (!int.TryParse(Console.ReadLine(), out tempCount))
            {
                Console.WriteLine(Messages.ExceptionMessages.countError);
            }

            if (tempCount < 0)
                Console.WriteLine("Write only positive numbers");

            if (tempCount >= _productsTemp[_productNumber]._count)
            {
                Basket.AddToBasket(_productsTemp[_productNumber]);
                _productsTemp.RemoveAt(_productNumber);
            }
            else
            {
                _productsTemp[_productNumber]._count -= tempCount;
                Product tempProduct = new Product(_productsTemp[_productNumber]._name,
                    tempCount,
                    _productsTemp[_productNumber]._price,
                    _productsTemp[_productNumber]._id);

                Basket.AddToBasket(tempProduct);
                ShowMenu();
            }
        }

        private void ChangePriceProduct()
        {

            double tempPrice;
            Console.WriteLine("Write new price");

            while (!Double.TryParse(Console.ReadLine(), out tempPrice))
            {
                Console.WriteLine(Messages.ExceptionMessages.priceError);
            }
            _productsTemp[_productNumber]._price = tempPrice;

            ShowMenu();
        }

        private void AddCountProduct()
        {
            int tempCount = 0;
            Console.WriteLine(Messages.HelpersMessages.countAdd);

            while (!int.TryParse(Console.ReadLine(), out tempCount))
            {
                Console.WriteLine(Messages.ExceptionMessages.countError);
            }

            _productsTemp[_productNumber]._count += tempCount;
            ShowMenu();
        }

        private void RemoveCountProduct()
        {
            Console.WriteLine("Write count to remove");
            int tempCount = 0;

            while (!int.TryParse(Console.ReadLine(), out tempCount))
            {
                Console.WriteLine(Messages.ExceptionMessages.countError);
            }

            if (tempCount >= _productsTemp[_productNumber]._count)
            {
                Console.WriteLine("Product removed. Press any key to continue");
                _productsTemp.RemoveAt(_productNumber);
                Console.ReadKey();
            }
            else
            {
                _productsTemp[_productNumber]._count -= tempCount;

                ShowMenu();
            }
        }

        public void ShowMenu()
        {
            ShowProductInfo(_productNumber);

            for (int i = 0; i < Messages.MenuItems._productMenuItems.Length; i++)
            {
                if (_chooseMenu - 1 == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"----->\t{Messages.MenuItems._productMenuItems[i]}");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.WriteLine($"\t{Messages.MenuItems._productMenuItems[i]}");
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
