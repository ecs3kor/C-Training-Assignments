using System.Reflection.Metadata;
using System.Xml.Linq;
using static Crayon.Output;

namespace LINQExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allCustomers = from customer in GetAllCustomer()
                               //where customer.City.EndsWith("i")
                               orderby customer.ContactName,customer.City 
                               select customer;
            foreach (var customer in allCustomers)
            {
                Console.WriteLine($"{customer.ContactName} lives in {customer.City}");
            }
            Console.WriteLine();
            Console.WriteLine();

            var customerOrders = from customer in GetAllCustomer()
                                 join
                                 order in GetAllOrders()
                                 on customer.CustomerId equals order.CustomerId
                                 join 
                                 product in GetAllXMLProducts()
                                 on order.ProductId equals product.ProductId
                                 select new {CustomerName = customer.ContactName,LivingCity = customer.City,OrderId = order.OrderID,odate = order.OrderDate, reqDate = order.RequiredDate, oqty = order.Quantity, totalAmt = order.Quantity* product.UnitPrice,prodName= product.ProductName};
            foreach(var order  in customerOrders)
            {
                Console.WriteLine($"Customer {Red(order.CustomerName)} who lives in city {Green(order.LivingCity)} has placed order on {order.odate} and it is delivered on {order.reqDate} and number of orders purchased is {order.oqty} \n Product name is {Yellow(order.prodName)} and Total Amount is {Blue((order.totalAmt).ToString())}");
            }

            Console.WriteLine();
            Console.WriteLine();

           
        }
        private static List<Customer> GetAllCustomer()
        {
            //Collection initializer
            return new List<Customer>()
    {
                //Object initializer
        new(){CustomerId = 1, ContactName="Alisha C.",City="Mumbai"},
        new(){CustomerId = 2, ContactName="Manas Jha",City="Mumbai"},
        new(){CustomerId = 3, ContactName="Maria Johns",City="London"},
        new(){CustomerId = 4, ContactName="John Marks",City="Berlin"},
    };
        }

        private static List<Product> GetAllXMLProducts()
        {
            var products = from XMLProduct in XElement.Load(@"C:\Users\ECS3KOR\Documents\Bosch- C#Training\InMemoryData\LINQExample\ProductList.xml").Elements()
                           select new Product
                           {
                               ProductId = int.Parse(XMLProduct.Attribute("ProductId").Value),
                               ProductName = XMLProduct.Attribute("ProductName").Value,
                               UnitPrice = double.Parse(XMLProduct.Attribute("UnitPrice").Value),
                               CompanyName = XMLProduct.Attribute("CompanyName").Value

                           };
            return products.ToList();
           
        }

        private static List<Order> GetAllOrders()
        {
            return new List<Order>()
            {
                new(){CustomerId =1, OrderID = 1, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 20, ProductId=1001},
                new(){CustomerId =2, OrderID = 2, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 20,ProductId=1001},
                new(){CustomerId =3, OrderID = 3, OrderDate = DateTime.Now, RequiredDate = DateTime.Now.AddDays(2), Quantity = 20,ProductId=1004}
            };
        }
    }
}
