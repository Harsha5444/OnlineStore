using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL;

namespace OnlineStore.UI
{
    class Cart
    {
        private string UserName;
        DataTable cartTable;
        public Cart()
        {

        }
        public Cart(string userName)
        {
            UserName = userName;
        }
        public void GetCartTable()
        {
            CartBLL cartBLL = new CartBLL(UserName);
            cartTable = cartBLL.GetCartTable();
            foreach (DataColumn column in cartTable.Columns)
            {
                Console.Write($"{column.ColumnName,-20}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', cartTable.Columns.Count * 20));
            foreach (DataRow row in cartTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-20}");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', cartTable.Columns.Count * 20));
        }
    }
}
