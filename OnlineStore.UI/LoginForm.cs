using OnlineStore.BLL;
using OnlineStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI
{
    class LoginForm
    {
        public void Login()
        {
            Console.WriteLine("Welcome to Online Store!");
            UserBLL userBLL = new UserBLL();
            DataTable usersTable = userBLL.GetUsersTable();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter username: ");
                        string username = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        if (userBLL.Login(username, password))
                        {
                            Console.WriteLine("Login successful! Welcome, " + username + ".");
                        }
                        else
                        {
                            Console.WriteLine("Login failed! Invalid username or password.");
                        }
                        break;

                    case "2":
                        Console.Write("\nEnter full name: ");
                        string fullname = Console.ReadLine();

                        Console.Write("Enter username: ");
                        string newUsername = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string newPassword = Console.ReadLine();

                        Console.Write("Enter mobile number: ");
                        string mobileNumber = Console.ReadLine();

                        if (userBLL.Register(fullname, newUsername, newPassword, mobileNumber))
                        {
                            Console.WriteLine("Registration successful!");
                        }
                        else
                        {
                            Console.WriteLine("Registration failed! Username already exists.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting the application. Saving changes...");
                        userBLL.SaveUsers(usersTable);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
