/*SOLID Principle Implementation -
            1.) Single Responsibility - Created seperate classes for each entity having only one kind of related functionality.
            2.) Open Closed Principle - Created Interface IInvoiceGeneratoe to implement invoice generation for order placement Employee,Supplier or whoever might need it so open to extension by implementing interfaces but closed for changes.
            3.) Liskov’s Substitution Principle - Classes Shipper & Supplier are base classes of MerchantDetails and are substitutable to parent class.
            4.) Interface Segregation Principle -Build Interfaces so that only necessary classes have to implement it.
            5.) Dependency Inversion Principle - For Invoice generation injected dependency via IInvoiceGenerator into supplier, shipper & order details classes.
            */


using PurchaseOrder.Models;

Customer customer = new Customer() { CustomerId = 1, CustomerName = "Anne Marie", CustomerAddress = "Miami", CustomerEmail = "Anne@gmail.com", CustomerPhone = 999999999 };

//Create Employee who will process order
Employee employee = new Employee() { EmpoyeeId = 1, EmployeeName = "Anne" };

//Create New Category For Customer
Category category = new Category() { CategoryId = 1, CategoryName = "Shoes", CategoryDescription = "Wearables" };

//Create Product for Above Category
Product product = new Product() { ProductId = 1, ProductName = "Puma", ProductPrice = 3400, ProductDescription = "Forever faster", ProductCategory = category };

//Create New Order for Above Product
Order order = new Order() { OrderID = 1, Quantity = 2, Product = product, Price = 8900, OrderProcessingEmployee = employee };

//Create Order Details
OrderDetails orderDetails = new OrderDetails() { CustomerInfo = customer, OrderInfo = order };

//Generate Invoice for Customer
Invoice invoice = new Invoice() { InvoiceId = 1, Quantity = order.Quantity, unitPrice = order.Price };

Shipper shipper = new Shipper(invoice) { Id = 1, Name = "CartShippers", Description = "CartShippers shipments pvt. ltd.", ShippingCharges = 200 };
Supplier supplier = new Supplier(invoice) { Id = 1, Name = "Puma Outlet", Description = "Puma pvt. ltd.", SupplierCharges = 300 };

invoice.finalPrice = invoice.TotalPrice() + shipper.TotalShippingPrice() + supplier.TotalSupplierPrice();

Console.WriteLine($"Order details: \n InvocieID:{invoice.InvoiceId} \n ProductName: {orderDetails.OrderInfo.Product.ProductName} \n Quanity:{invoice.Quantity} \n TotalPrice:{invoice.finalPrice} ");
Console.ReadKey();