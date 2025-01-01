using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL;

namespace OnlineStore.UI
{
    class Cart : ProductList
    {
        public string UserName;
        public DataTable cartTable;
        public Cart()
        {

        }
        public Cart(string userName)
        {
            UserName = userName;
        }
        public void GetCartTable()
        {
            CartBLL cartBLL = new CartBLL(Session.UserName);
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
        public void AddToCart()
        {
            CartBLL cartBLL = new CartBLL(Session.UserName);
            cartTable = cartBLL.GetCartTable();
            DisplayProductList();
            Console.WriteLine("----Add Product To Cart----");
            Console.Write("Enter ProductID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int requestedQuantity = Convert.ToInt32(Console.ReadLine());

            // Find the product in the productTable
            DataRow productRow = null;
            foreach (DataRow row in productTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    productRow = row;
                    break;
                }
            }

            if (productRow == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            int availableQuantity = Convert.ToInt32(productRow["QuantityAvailable"]);
            if (requestedQuantity > availableQuantity)
            {
                Console.WriteLine("Insufficient stock. Available quantity: " + availableQuantity);
                return;
            }

            // Calculate the final price
            decimal price = Convert.ToDecimal(productRow["Price"]);
            decimal finalPrice = price * requestedQuantity;

            // Update the product table (deduct the quantity)
            productRow["QuantityAvailable"] = availableQuantity - requestedQuantity;

            // Add a new row to the cartTable
            DataRow newCartRow = cartTable.NewRow();
            newCartRow["ProductId"] = productId;
            newCartRow["Username"] = Session.UserName;
            newCartRow["Quantity"] = requestedQuantity;
            newCartRow["FinalPrice"] = finalPrice;
            cartTable.Rows.Add(newCartRow);
            cartBLL.Savecart(cartTable);
            Console.WriteLine("Product added to cart successfully.");
        }
    }
}
