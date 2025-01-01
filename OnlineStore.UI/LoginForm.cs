using OnlineStore.BLL;
using System;
using System.Data;

namespace OnlineStore.UI
{
    class LoginForm
    {
        public bool Login()
        {
            Cart session = new Cart(Session.UserName);
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
                        Session.UserName = username;
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
                    string fullname, newUsername, newPassword, mobileNumber;
                    do
                    {
                        Console.Write("\nEnter full name: ");
                        fullname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(fullname))
                        {
                            Console.WriteLine("Full name cannot be empty. Please try again.");
                        }
                    } while (string.IsNullOrWhiteSpace(fullname));
                    do
                    {
                        Console.Write("Enter username: ");
                        newUsername = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newUsername))
                        {
                            Console.WriteLine("Username cannot be empty. Please try again.");
                        }
                    } while (string.IsNullOrWhiteSpace(newUsername));
                    do
                    {
                        Console.Write("Enter password: ");
                        newPassword = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newPassword))
                        {
                            Console.WriteLine("Password cannot be empty. Please try again.");
                        }
                    } while (string.IsNullOrWhiteSpace(newPassword));
                    do
                    {
                        Console.Write("Enter mobile number: ");
                        mobileNumber = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(mobileNumber))
                        {
                            Console.WriteLine("Mobile number cannot be empty. Please try again.");
                        }
                    } while (string.IsNullOrWhiteSpace(mobileNumber));
                    if (userBLL.Register(fullname, newUsername, newPassword, mobileNumber))
                    {
                        Console.Clear();
                        Session.UserName = newUsername;
                        Console.WriteLine("Registration successful!\n");
                        userBLL.SaveUsers(usersTable);
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Registration failed! Username already exists.\nPlease try with a different username.\n");
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
