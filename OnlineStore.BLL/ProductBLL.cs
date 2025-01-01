using OnlineStore.DAL;
using System.Data;

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
