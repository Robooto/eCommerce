using eCommerce.Contracts.Model;
using eCommerce.Contracts.Modules;
using eCommerce.Contracts.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Modules.Vouchers.PercentOff
{
    public class eVoucher : IeVoucher
    {

        public void ProcessVoucher(IVoucher voucher, IBasket basket, IBasketVoucher basketVoucher)
        {
            if (voucher.MinSpend < basket.BasketTotal())
            {
                basketVoucher.Value = voucher.Value * (basket.BasketTotal() / 100);
                basketVoucher.VoucherCode = voucher.VoucherCode;
                basketVoucher.VoucherDescription = voucher.VoucherDescription;
                basketVoucher.VoucherId = voucher.VoucherId;
                basket.AddBasketVoucher(basketVoucher);
            }

            
        }
    }
}
