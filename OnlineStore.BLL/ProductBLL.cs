using OnlineStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL
{
    public class ProductBLL
    {
        private DataTable productTable;
        ProductDAL productDAL = new ProductDAL();
        public ProductBLL()
        {
            productTable = productDAL.GetProductTable();
        }
        public DataTable GetProductTable()
        {
            return productTable;
        }
        public void saveProducts(DataTable productTable)
        {
            productDAL.SaveProductTable(productTable);
        }
    }
}
