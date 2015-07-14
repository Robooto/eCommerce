using System;
namespace eCommerce.Contracts.Model
{
    public interface IVoucherType
    {
        string Description { get; set; }
        string Type { get; set; }
        string VoucherModule { get; set; }
        int VoucherTypeId { get; set; }
    }
}
