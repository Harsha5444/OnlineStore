using OnlineStore.BLL;
using System;
using System.Data;

namespace OnlineStore.UI
{
    class ProductList
    {
        public void productList()
        {
            ProductBLL productBLL = new ProductBLL();
            DataTable productTable = productBLL.GetProductTable();
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
