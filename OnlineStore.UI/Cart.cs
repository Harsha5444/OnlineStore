using OnlineStore.BLL;
using System;
using System.Data;

namespace OnlineStore.UI
{
    class Cart
    {
        public string UserName;
        public DataTable cartTable;
        private ProductList productList; // Reference to shared ProductList instance
        CartBLL cartBLL = new CartBLL();

        // Default constructor
        public Cart()
        {
            productList = new ProductList(); // Create a new ProductList if not provided
            cartTable = cartBLL.GetCartTable();
        }

        // User-defined constructor
        public Cart(ProductList productList)
        {
            this.productList = productList; // Use the provided ProductList instance
            cartTable = cartBLL.GetCartTable();
        }

        public void DisplayCartTable()
        {
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
            DataTable productTable = productList.productTable;
            Console.WriteLine("----Add Product To Cart----");
            Console.Write("Enter ProductID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int requestedQuantity = Convert.ToInt32(Console.ReadLine());
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
            decimal price = Convert.ToDecimal(productRow["Price"]);
            decimal finalPrice = price * requestedQuantity;
            productRow["QuantityAvailable"] = availableQuantity - requestedQuantity;
            DataRow newCartRow = cartTable.NewRow();
            newCartRow["ProductId"] = productId;
            newCartRow["Username"] = Session.UserName;
            newCartRow["Quantity"] = requestedQuantity;
            newCartRow["FinalPrice"] = finalPrice;
            cartTable.Rows.Add(newCartRow);
            productList.UpdateProducts(productTable);
            Console.WriteLine("Product added to cart successfully.");
        }
    }
}
