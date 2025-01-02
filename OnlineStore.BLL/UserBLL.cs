using OnlineStore.DAL;
using System.Data;

namespace OnlineStore.BLL
{
    public class UserBLL
    {
        private DataTable usersTable;
        UserDAL userDAL = new UserDAL();
        public UserBLL()
        {
            usersTable = userDAL.GetUsersTable();
        }
        public DataTable GetUsersTable()
        {
            return usersTable;
        }
        public void SaveUsers(DataTable usersTable)
        {
            userDAL.SaveUsers(usersTable);
        }
    }
}
