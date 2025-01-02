using OnlineStore.DAL;
using System.Data;

namespace OnlineStore.BLL
{
    public class CartBLL
    {
        private DataTable cartTable;
        CartDAL cartDAL = new CartDAL();

        public CartBLL()
        {
            cartTable = cartDAL.GetCartTable();
        }
        public DataTable GetCartTable()
        {
            return cartTable;
        }
        public void Savecart(DataTable cartTable)
        {
            cartDAL.SaveCart(cartTable);
        }
    }
}
