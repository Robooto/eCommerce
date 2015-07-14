using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string Address1 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}
