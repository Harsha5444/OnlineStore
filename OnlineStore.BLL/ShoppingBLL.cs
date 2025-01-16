using OnlineStore.DAL;
using System.Data;

namespace OnlineStore.BLL
{
    internal class ShoppingBLL
    {
        DataSet ds;
        public ShoppingBLL()
        {
            ShoppingDAL DAL = new ShoppingDAL();
            ds = DAL.GetDataSet();
        }
    }
}
