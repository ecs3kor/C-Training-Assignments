﻿namespace LINQExample
{
    internal class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}