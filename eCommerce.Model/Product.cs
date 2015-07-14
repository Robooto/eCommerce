using eCommerce.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }

        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
    }
}
