namespace Products
{
    public static class Messages
    {
        public static class MenuItems
        {
            public static readonly string[] _mainMenuItems = new string[]
                {"Add to inventory", "Show Inventory", "Show Basket", "Clear Basket"};

            public static readonly string[] _productMenuItems = new string[] { $"Delete some count of products",
                "Delete this product full",
                "Add some count product",
                "Change price",
                "Add to basket"
            };
        }

        public static class ExceptionMessages
        {
            public static readonly string countError = "Please write correct count";
            public static readonly string priceError = "Please write correct price";
        }

        public static class HelpersMessages
        {
            public static readonly string productInBasket = "Product in basket";
            public static readonly string emptyBasket = "Basket is empty. Click any key to return";
            public static readonly string emptyInventory = "Inventory is empty. Press any key to back in main menu";
            public static readonly string backSpaceToReturn = "Press BackSpace to return in menu";
            public static readonly string countAdd = "Write count to add";
        }
    }
}