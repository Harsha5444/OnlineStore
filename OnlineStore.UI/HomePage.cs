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
            Console.WriteLine($"0. View Products");
            Console.WriteLine($"1. View Cart");
            Console.WriteLine($"2. Add Product(s) To Cart");
            Console.WriteLine($"3. CheckOut");
            Console.WriteLine($"4. LogOut");
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
                    // Implement checkout logic here (if needed)
                    Console.WriteLine("Proceeding to checkout...");
                    break;
                case "4":
                    Console.Clear();
                    Logout();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Please Enter a Valid Choice!");
                    Menu();
                    break;
            }
        }

        // Logout method
        public void Logout()
        {
            // Clear the session (log the user out)
            Session.UserName = null;
            Console.WriteLine("You have successfully logged out.");
            Console.WriteLine("Redirecting to login screen...");

            // Optionally, you can return to the login screen, or exit the program
            LoginForm loginForm = new LoginForm();
            loginForm.Login(); // This will return the user to the login form
        }
    }
}
