using System;
namespace eCommerce.Contracts.Model
{
    public interface IVoucher
    {
        int AppliesToProductId { get; set; }
        string AssignedTo { get; set; }
        decimal MinSpend { get; set; }
        bool multipleUse { get; set; }
        decimal Value { get; set; }
        string VoucherCode { get; set; }
        string VoucherDescription { get; set; }
        int VoucherId { get; set; }
        int VoucherTypeId { get; set; }
    }
}
