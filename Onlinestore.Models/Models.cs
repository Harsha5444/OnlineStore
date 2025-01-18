using System;

namespace Onlinestore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
    public class Cart
    {
        public string ProductName { get; set; }
        public string Username { get; set; }
        public int Quantity { get; set; }
        public int FinalPrice { get; set; }
    }
    public class Orders
    {
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDetails { get; set; }
    }
}
