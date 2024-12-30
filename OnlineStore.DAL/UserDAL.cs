using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL
{
    public class UserDAL : ConnectionDAL
    {
        private DataTable usersTable;
        public UserDAL()
        {
            LoadUsers();
        }
        private void LoadUsers()
        {
            usersTable = new DataTable();
            string query = "SELECT * FROM Users";
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(usersTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading users: " + ex.Message);
                }
            }
        }
        public DataTable GetUsersTable()
        {
            return usersTable.Copy();
        }
        public void SaveUsers(DataTable usersTable)
        {
            string query = "SELECT * FROM Users";
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(usersTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving users: " + ex.Message);
                }
            }
        }
    }
}

