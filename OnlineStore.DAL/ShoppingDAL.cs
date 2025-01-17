using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStore.DAL
{
    public class ShoppingDAL
    {
        public DataSet GetDataSet()
        {
            var ds = new DataSet("DataBase");
            var queries = new (string query, string tableName)[]
            {
                ("SELECT * FROM Users", "Users"),
                ("SELECT * FROM Products", "Products"),
                ("SELECT * FROM Orders", "Orders")
            };
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChoiceCon"].ConnectionString))
                {
                    foreach (var (query, tableName) in queries)
                    {
                        using (var da = new SqlDataAdapter(query, conn))
                        {
                            da.Fill(ds, tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return ds;
        }
        public bool AddNewUser(DataSet ds)
        {
            DataTable usersTable = ds.Tables["Users"];
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChoiceCon"].ConnectionString))
            {
                using (var da = new SqlDataAdapter("SELECT * FROM Users", conn))
                {
                    var commandBuilder = new SqlCommandBuilder(da);
                    try
                    {
                        da.Update(usersTable);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding new user: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}