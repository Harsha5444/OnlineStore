using OnlineStore.BLL;
using System;

namespace OnlineStore.UI
{
    internal class ShoppingUI
    {       
        static void Main(string[] args)
        {
            ShoppingBLL BLL = new ShoppingBLL();
            //Display.DisplayList(BLL.GetCart(),"Cart");
            //Display.DisplayList(BLL.GetProducts(), "Products");
            //Display.DisplayList(BLL.GetOrders(), "Orders");
            //Display.DisplayList(BLL.GetUsers(), "Users");
            BLL.GetCart();
            BLL.GetProducts();
            BLL.GetOrders();
            BLL.GetUsers();
            Console.Read();
        }
    }
}
