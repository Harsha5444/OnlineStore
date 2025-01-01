using System;
using System.Data;
using OnlineStore.BLL;
using OnlineStore.DAL;

namespace OnlineStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginForm loginForm = new LoginForm();
            loginForm:
            if (loginForm.Login())
            {
                //ProductList product = new ProductList();
                //product.productList();
            }
            else
            {
                goto loginForm;
            }
            Console.Read();
        }
    }
}
