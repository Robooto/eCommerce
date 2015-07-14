using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
