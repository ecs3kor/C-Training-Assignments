using Bosch.eCommerce.Models;
using Microsoft.EntityFrameworkCore;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bosch.eCommerce.DAL
{
    public class ECommerceDBContext : DbContext 
    {
        public ECommerceDBContext()
        {
            
        }
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : base()
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = KOR-C-002EU\SQLEXPRESS; Initial Catalog = SynechronECommerceDb; Trusted_Connection = true; TrustServerCertificate = True;");
        }

    }
}
