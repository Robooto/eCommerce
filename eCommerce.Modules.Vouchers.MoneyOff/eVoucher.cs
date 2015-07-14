using eCommerce.Contracts.Model;
using eCommerce.Contracts.Modules;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Modules.Vouchers.MoneyOff
{
    class eVoucher : IeVoucher
    {
        public void ProcessVoucher(IVoucher voucher, IBasket basket, IBasketVoucher basketVoucher)
        {
            if (voucher.MinSpend < basket.BasketTotal())
            {
                basketVoucher.Value = voucher.Value;
                basketVoucher.VoucherCode = voucher.VoucherCode;
                basketVoucher.VoucherDescription = voucher.VoucherDescription;
                basketVoucher.VoucherId = voucher.VoucherId;
                basket.AddBasketVoucher(basketVoucher);
            }  
        }
    }
}
