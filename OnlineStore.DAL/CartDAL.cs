using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL
{
    public class CartDAL : ConnectionDAL
    {
        private DataTable cartTable;
        private string UserName;
        public CartDAL(string userName)
        {
            UserName = userName;
            LoadCart();
        }
        private void LoadCart()
        {
            cartTable = new DataTable();
            String query = $"Select * from Cart where username = '{UserName}'";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(cartTable);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
        public DataTable GetCart()
        {
            return cartTable.Copy();
        }
        public bool SaveCart(DataTable cartTable)
        {
            return true;
        }
    }
}
