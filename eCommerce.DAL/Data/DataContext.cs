using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// You can either pass the Name of a connection string from web config or explicity declare one
        /// </summary>
        public DataContext() 
            : base("DefaultConnection")
        {

        }

        /// <summary>
        /// All persistent entities must be declared
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<BasketVoucher> BasketVouchers { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
    }
}
