using eCommerce.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class VoucherType : IVoucherType
    {
        public int VoucherTypeId { get; set; }
        public string VoucherModule { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
