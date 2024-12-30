using System;
using System.Data;

namespace OnlineStore.BLL
{
    public class UserBLL
    {
        private DataTable usersTable;

        public UserBLL(DataTable usersData)
        {
            usersTable = usersData;
        }
        public bool Login(string username, string password)
        {
            foreach (DataRow row in usersTable.Rows)
            {
                if (row["username"].ToString() == username && row["password"].ToString() == password)
                {
                    return true;
                }
            }
            return false; 
        }
        public bool Register(string fullname, string username, string password, string mobilenumber)
        {
            foreach (DataRow row in usersTable.Rows)
            {
                if (row["username"].ToString() == username)
                {
                    return false;
                }
            }
            DataRow newRow = usersTable.NewRow();
            newRow["fullname"] = fullname;
            newRow["username"] = username;
            newRow["password"] = password;
            newRow["mobilenumber"] = mobilenumber;
            usersTable.Rows.Add(newRow);
            return true; 
        }
        public DataTable GetUsers()
        {
            return usersTable;
        }
    }
}
