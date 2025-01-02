using System;

namespace OnlineStore.UI
{
    class HomePage
    {
        private ProductList productTable = new ProductList(); // Shared ProductList instance
        private Cart cartTable;

        public HomePage()
        {
            cartTable = new Cart(productTable); // Use the shared ProductList
        }

        public HomePage(string userName)
        {
            cartTable = new Cart(productTable); // Shared ProductList
            cartTable.UserName = userName;      // Additional customization
        }

        public void Menu()
        {
            Console.WriteLine($"What Would You Like To Do?");
            Console.WriteLine($"0.View Products");
            Console.WriteLine($"1.View cart");
            Console.WriteLine($"2.Add Product(s) To Cart");
            Console.WriteLine($"3.CheckOut");
            Console.WriteLine($"4.LogOut");
            Console.Write($"Enter Your Choice(1, 2, 3, 4): ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    Console.Clear();
                    productTable.DisplayProductList();
                    Menu();
                    break;
                case "1":
                    Console.Clear();
                    cartTable.DisplayCartTable();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    productTable.DisplayProductList();
                    cartTable.AddToCart();
                    Menu();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Please Enter a Valid Choice!");
                    Menu();
                    break;
            }
        }
    }
}
