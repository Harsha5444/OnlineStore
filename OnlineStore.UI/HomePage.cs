using System;

namespace OnlineStore.UI
{
    class HomePage
    {
        public void Menu()
        {
            Console.WriteLine($"What Would You Like To Do?");
            Console.WriteLine($"1.View Products");
            Console.WriteLine($"2.Add Product(s) To Cart");
            Console.WriteLine($"3.CheckOut");
            Console.WriteLine($"4.LogOut");
            Console.Write($"Enter Your Choice(1, 2, 3, 4): ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();    
                    ProductList products = new ProductList();
                    products.productList();
                    Menu();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine($"Please Enter a Valid Choice!");
                    Menu();
                    break;
            }
        }
    }
}
