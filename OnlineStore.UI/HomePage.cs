using System;

namespace OnlineStore.UI
{
    class HomePage
    {
        private ProductList productTable = new ProductList(); 
        private Cart cartTable;

        public HomePage()
        {
            cartTable = new Cart(productTable); 
        }

        public HomePage(string userName)
        {
            cartTable = new Cart(productTable); 
            cartTable.UserName = userName;     
        }

        public void Menu()
        {
            Console.WriteLine($"What Would You Like To Do?");
            Console.WriteLine($"0.View Products");
            Console.WriteLine($"1.View Cart");
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
                    Console.Clear();
                    cartTable.Checkout();
                    Menu();
                    break;
                case "4":
                    Console.WriteLine("Logging out...");
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
