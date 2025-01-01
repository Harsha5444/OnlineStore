using OnlineStore.BLL;
using System;
using System.Data;

namespace OnlineStore.UI
{
    class ProductList
    {
        private ProductBLL productBLL;
        public DataTable productTable;

        public ProductList()
        {
            productBLL = new ProductBLL();
            productTable = productBLL.GetProductTable();
        }
        public void DisplayProductList()
        {
            if (productTable == null || productTable.Rows.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            foreach (DataColumn column in productTable.Columns)
            {
                Console.Write($"{column.ColumnName,-20}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', productTable.Columns.Count * 20));
            foreach (DataRow row in productTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-20}");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', productTable.Columns.Count * 20));
        }
    }
}
