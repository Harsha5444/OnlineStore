using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DAL;

namespace OnlineStore.BLL
{
    public class CartBLL
    {
        private string UserName;
        DataTable cartTable;
        public CartBLL(string userName)
        {
            UserName = userName;
        }
        public DataTable GetCartTable()
        {
            CartDAL cartDAL = new CartDAL(UserName);
            cartTable = cartDAL.GetCart();
            return cartTable;
        }
    }
}
