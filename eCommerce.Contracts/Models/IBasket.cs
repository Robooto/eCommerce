using System;
using System.Collections.Generic;
namespace eCommerce.Contracts.Model
{
    public interface IBasket
    {
        Guid BasketId { get; set; }
        
        ICollection<IBasketItem> IBasketItems { get; }
        ICollection<IBasketVoucher> IBasketVouchers { get; }
        DateTime date { get; set; }

        void AddBasketItem(IBasketItem item);
        void AddBasketVoucher(IBasketVoucher voucher);
        decimal BasketTotal();
        decimal BasketItemCount();
    }
}
