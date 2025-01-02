using System;

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
                HomePage homePage = new HomePage();
                homePage.Menu();
            }
            else
            {
                goto loginForm;
            }
            Console.Read();
        }
    }
}
