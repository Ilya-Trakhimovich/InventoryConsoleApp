using System;

 namespace Products
{
    public class Product
    {
        public string _name;
        public int _count;
        public Guid _id { get; private set; }
        public double _price;

        public Product(string name, int count, double price)
        {
            _name = name;
            _count = count;
            _price = price;
            _id = Guid.NewGuid();
        }

        public Product(string name, int count, double price, Guid id)
        {
            _name = name;
            _count = count;
            _price = price;
            _id = id;
        }
    }
}