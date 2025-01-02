using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStore.DAL
{
    public class CartDAL : ConnectionDAL
    {
        private DataTable cartTable;
        public CartDAL()
        {
            LoadCart();
        }
        private void LoadCart()
        {
            cartTable = new DataTable();
            String query = $"Select * from Cart";
            using (SqlConnection con = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(cartTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
        public DataTable GetCartTable()
        {
            return cartTable.Copy();
        }
        public void SaveCart(DataTable cartTable)
        {
            string query = "select * from cart";
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(cartTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
    }
}
