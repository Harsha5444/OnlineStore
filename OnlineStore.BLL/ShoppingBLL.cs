using Onlinestore.Models;
using OnlineStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OnlineStore.BLL
{
    public class ShoppingBLL
    {
        private DataSet ds;
        private ShoppingDAL DAL;
        public ShoppingBLL()
        {
            DAL = new ShoppingDAL();
            ds = DAL.GetDataSet();
        }
        public bool LoginVerify(string username, string password)
        {
            DataTable usersTable = ds.Tables["Users"];
            var user = usersTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("Username") == username && row.Field<string>("Password") == password);
            return user != null;
        }
        public bool RegisterUser(string username, string fullname, string password, string mobilenumber)
        {
            try
            {
                DataTable usersTable = ds.Tables["Users"];
                DataRow newUserRow = usersTable.NewRow();
                newUserRow["Username"] = username;
                newUserRow["FullName"] = fullname;
                newUserRow["Password"] = password;
                newUserRow["MobileNumber"] = mobilenumber;
                usersTable.Rows.Add(newUserRow);
                bool isUserAdded = DAL.AddNewUser(ds);
                if (isUserAdded)
                {                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }
        public List<User> ConvertDataTableToUserList(DataTable dataTable)
        {
            var userList = new List<User>();
            foreach (DataRow row in dataTable.Rows)
            {
                var user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    FullName = Convert.ToString(row["FullName"]),
                    Username = Convert.ToString(row["Username"]),
                    Password = Convert.ToString(row["Password"]),
                    MobileNumber = Convert.ToString(row["MobileNumber"]),
                };
                userList.Add(user);
            }
            return userList;
        }
        public List<Product> ConvertDataTableToProductList(DataTable dataTable)
        {
            var productList = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                var product = new Product
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = Convert.ToString(row["ProductName"]),
                    Price = Convert.ToInt32(row["Price"]),
                    QuantityAvailable = Convert.ToInt32(row["QuantityAvailable"]),
                };
                productList.Add(product);
            }
            return productList;
        }
        public List<Orders> ConvertDataTableToOrderList(DataTable dataTable)
        {
            var orderList = new List<Orders>();
            foreach (DataRow row in dataTable.Rows)
            {
                var order = new Orders
                {
                    Username = Convert.ToString(row["Username"]),
                    TotalCost = Convert.ToDecimal(row["TotalCost"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    OrderDetails = Convert.ToString(row["OrderDetails"]),
                };
                orderList.Add(order);
            }
            return orderList;
        }
        public List<User> GetUsers()
        {
            if (ds.Tables["Users"] != null)
            {
                return ConvertDataTableToUserList(ds.Tables["Users"]);
            }
            return new List<User>();
        }
        public List<Product> GetProducts()
        {
            if (ds.Tables["Products"] != null)
            {
                return ConvertDataTableToProductList(ds.Tables["Products"]);
            }
            return new List<Product>();
        }
        public List<Cart> GetCart()
        {            
            return new List<Cart>();
        }
        public List<Orders> GetOrders()
        {
            if (ds.Tables["Orders"] != null)
            {
                return ConvertDataTableToOrderList(ds.Tables["Orders"]);
            }
            return new List<Orders>();
        }
    }
}
