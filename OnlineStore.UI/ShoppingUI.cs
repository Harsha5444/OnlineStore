using Onlinestore.Models;
using OnlineStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnlineStore.UI
{
    public class Session
    {
        public static string Username { get; set; }
    }
    public class ShoppingUI
    {
        static void Main(string[] args)
        {
            ShoppingUI UI = new ShoppingUI();
            ShoppingBLL BLL = new ShoppingBLL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Online Store!");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.Write("Please choose an option: ");
                string choice = Console.ReadLine();

                /*----------------------------Login-------------------------*/
                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("********** Login **********");
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    if (BLL.LoginVerify(username, password))
                    {
                        Console.Clear();
                        Console.WriteLine($"Login Successful, Welcome '{username}'\n");
                        Session.Username = username;
                        UI.Menu(BLL); // Navigate to menu
                    }
                    else
                    {
                        Console.WriteLine($"No credentials found for user '{username}'. Please check your username or password.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                /*----------------------------Register-------------------------*/
                else if (choice == "2")
                {
                    List<Models> users = BLL.GetUsers();
                    Console.Clear();
                    Console.WriteLine("********** Register **********");
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    if (char.IsDigit(username[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Username should not start with a number.\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    if (users.Any(u => u.Username == username))
                    {
                        Console.Clear() ;
                        Console.WriteLine($"A user with the username '{username}' already exists.\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    Console.Write("Enter Full Name: ");
                    string fullName = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter Mobile Number: ");
                    string mobileNumber = Console.ReadLine();
                    if (BLL.RegisterUser(username, fullName, password, mobileNumber))
                    {
                        Console.Clear();
                        Console.WriteLine($"User {username}, registered successfully.\n");
                        Session.Username = username;
                        UI.Menu(BLL); 
                    }
                    else
                    {
                        Console.WriteLine("Failed to register user.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option selected. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }


        /*----------------------------------Menu---------------------------------------*/

        public void Menu(ShoppingBLL BLL)
        {
            Console.WriteLine("********** Welcome to the Home Page **********");
        start:
            Console.WriteLine("Please choose an option from the menu below:");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Logout");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Display.DisplayList(BLL.GetProducts(), "Products");
                    goto start;
                case "2":
                    AddToCart(BLL);
                    goto start;
                case "3":
                    Console.Clear();
                    Display.DisplayList(BLL.GetCart(), "Cart");
                    goto start;
                case "4":
                    Checkout(BLL);
                    Console.Clear();
                    goto start;
                case "5":
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }

        /*-------------------------------Add to cart-------------------------------*/

        public void AddToCart(ShoppingBLL BLL)
        {
            Console.Clear();
            Display.DisplayList(BLL.GetProducts(), "Products");
            Console.WriteLine("\n*** Add to Cart ***");
            Console.WriteLine("Enter the Product ID you want to add to your cart:");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Enter the quantity:");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    if (BLL.AddToCart(productId, quantity, Session.Username))
                    {
                        Console.Clear();
                        Console.WriteLine("Product added to cart successfully!\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Failed to add product to cart. Please check the product ID and quantity.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID. Please enter a valid number.\n");
            }
        }

        /*-------------------------------checkout-------------------------------*/

        public void Checkout(ShoppingBLL BLL)
        {
            if (BLL.GetCart() == null || !BLL.GetCart().Any())
            {
                Console.Clear();
                Console.WriteLine("Your cart is empty. Cannot proceed with checkout.\n");
                return;
            }
            var (totalcost, orderDate, orderDetails) = BLL.Checkout(Session.Username);
            if (orderDetails != null)
            {
                PaymentGateway();
                Console.Clear();
                Console.WriteLine("********** Order Confirmation **********");
                Console.WriteLine($"Order placed successfully by {Session.Username}.");
                Console.WriteLine($"Total Cost: {totalcost}");
                Console.WriteLine($"Order Date: {orderDate}");
                Console.WriteLine($"Order Details: {orderDetails}");
                Console.WriteLine("\nPress any key to return to the homepage.");
                Console.ReadKey();
            }
        }

        /*-------------------------------PaymentGateway-------------------------------*/

        public void PaymentGateway()
        {
            Console.Clear();
            Console.WriteLine("********** Payment Methods **********");
            Console.WriteLine("1. Credit/Debit Card");
            Console.WriteLine("2. Net Banking");
            Console.WriteLine("3. UPI");
            Console.WriteLine("4. Cash on Delivery");
            Console.Write("Select a payment method: ");
            string paymentMethod = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("********** Payment Gateway **********");
            Console.WriteLine("Redirecting to the payment gateway...");
            System.Threading.Thread.Sleep(3000); // Wait for 3 seconds
            Console.WriteLine("Processing payment...");
            for (int i = 0; i < 5; i++) 
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000); 
            }
            Console.WriteLine("\nPayment Successful!\n");
            Console.WriteLine("Thank you for shopping with us.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
    /*-------------------------------To display any List-------------------------------*/
    class Display
    {
        public static void DisplayList<T>(List<T> list, string tableName)
        {
            Console.Clear();
            if (list == null || list.Count == 0)
            {
                Console.WriteLine($"No data available in {tableName}.\n");
                return;
            }
            Console.WriteLine($"--- {tableName.ToUpper()} ---");
            PropertyInfo[] properties = typeof(T).GetProperties();
            Console.WriteLine(new string('-', 20 * properties.Length));
            foreach (var prop in properties)
            {
                Console.Write(prop.Name.PadRight(20));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 20 * properties.Length));
            foreach (var item in list)
            {
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item);
                    Console.Write(value.ToString().PadRight(20));
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20 * properties.Length));
            Console.WriteLine();
        }
    }
}
