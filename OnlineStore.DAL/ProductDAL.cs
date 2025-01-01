using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStore.DAL
{
    public class ProductDAL : ConnectionDAL
    {
        private DataTable productTable;
        public ProductDAL()
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            productTable = new DataTable();
            string query = "select * from products";
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(productTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
        public DataTable GetProductTable()
        {
            return productTable.Copy();
        }
        public void SaveProductTable(DataTable productTable)
        {
            string query = "select * from products";
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(productTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
    }
}
