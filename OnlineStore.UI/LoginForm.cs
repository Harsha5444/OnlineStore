using OnlineStore.BLL;
using System;
using System.Data;

namespace OnlineStore.UI
{
    class LoginForm
    {
        public bool Login()
        {
            Console.WriteLine("Welcome to Online Store!");
            UserBLL userBLL = new UserBLL();
            DataTable usersTable = userBLL.GetUsersTable();
            Console.WriteLine("\n1. Login");
            Console.WriteLine("2. Register");
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
                        Console.Clear();
                        Console.WriteLine("Login successful! Welcome, " + username + ".\n");
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Login failed! Invalid username or password.\nPlease Try Again..!\n");
                        return false;
                    }
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
                        Console.Clear();
                        Console.WriteLine("Registration successful!\n");
                        userBLL.SaveUsers(usersTable);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Registration failed! Username already exists.\nPlease Try with a different username\n");
                        return false;
                    }
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.\n");
                    return false;
            }
        }
    }
}
