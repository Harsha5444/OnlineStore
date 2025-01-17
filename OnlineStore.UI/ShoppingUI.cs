using Onlinestore.Models;
using OnlineStore.BLL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OnlineStore.UI
{
    internal class ShoppingUI
    {       
        static void Main(string[] args)
        {
            ShoppingBLL BLL = new ShoppingBLL();
            Console.WriteLine("Welcome to Online Store!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if(BLL.LoginVerify(username, password))
                    Console.WriteLine($"Login Successful, Welcome '{username}'\n");
                else
                    Console.WriteLine($"No credentials found for user '{username}'. Please check your username or password.");
            }
            else if (choice == "2")
            {
                List<User> users = BLL.GetUsers();
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                if (char.IsDigit(username[0]))
                {
                    Console.WriteLine("Username should not start with a number.");
                    return;
                }
                if (users.Any(u => u.Username == username))
                {
                    Console.WriteLine($"A user with the username '{username}' already exists.");
                    return;
                }
                Console.Write("Enter Full Name: ");
                string fullName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                Console.Write("Enter Mobile Number: ");
                string mobileNumber = Console.ReadLine();
                if(BLL.RegisterUser(username, fullName, password, mobileNumber))
                    Console.WriteLine($"User {username}, registered successfully.");
                else
                    Console.WriteLine("Failed to register user.");
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
            Console.ReadKey();
        }
    }
}
