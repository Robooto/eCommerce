
using eCommerce.Contracts.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Services
{
    public class BasketService
    {
        IRepositoryBase<Basket> baskets;
        private IRepositoryBase<Voucher> vouchers;
        private IRepositoryBase<VoucherType> voucherTypes;
        private IRepositoryBase<BasketVoucher> basketVouchers;

        public const string BasketSessionName = "eCommerceBasket";

        public BasketService(IRepositoryBase<Basket> baskets, IRepositoryBase<Voucher> vouchers, IRepositoryBase<BasketVoucher> basketVouchers, IRepositoryBase<VoucherType> voucherTypes)
        {
            this.baskets = baskets;
            this.vouchers = vouchers;
            this.basketVouchers = basketVouchers;
            this.voucherTypes = voucherTypes;
        }

        private Basket createNewBasket(HttpContextBase httpContext)
        {
            //create a new basket.

            //first create a new cookie.
            HttpCookie cookie = new HttpCookie(BasketSessionName);
            //now create a new basket and set the creation date.
            Basket basket = new Basket();
            basket.date = DateTime.Now;
            basket.BasketId = Guid.NewGuid();

            //add and persist in the dabase.
            baskets.Insert(basket);
            baskets.Commit();

            //add the basket id to a cookie
            cookie.Value = basket.BasketId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public bool AddToBasket(HttpContextBase httpContext, int productId, int quantity)
        {
            bool success = true;

            Basket basket = GetBasket(httpContext);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.BasketId,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.AddBasketItem(item);
            }
            else
            {
                item.Quantity = item.Quantity + quantity;
            }
            baskets.Commit();

            return success;
        }

        public Basket GetBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket;

            Guid basketId;

            if (cookie != null)
            {
                
                if(Guid.TryParse(cookie.Value, out basketId))
                {
                    basket = baskets.GetById(basketId);
                }
                else{
                    basket = createNewBasket(httpContext);
                }
            }
            else
            {
                basket = createNewBasket(httpContext);
            }

            return basket;
        }

        public void AddVoucher(string voucherCode, HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext);
            Voucher voucher = vouchers.GetAll().FirstOrDefault(v => v.VoucherCode == voucherCode);

            if (voucher != null)
            {
                VoucherType voucherType = voucherTypes.GetById(voucher.VoucherTypeId);
                if (voucherType != null)
                {
                    BasketVoucher basketVoucher = new BasketVoucher();
                    if (voucherType.Type == "MoneyOff")
                    {
                        MoneyOff(voucher, basket, basketVoucher);
                    }
                    if (voucherType.Type == "PercentOff")
                    {
                        PercentOff(voucher, basket, basketVoucher);
                    }

                    baskets.Commit();
                }
            }

        }

        public void MoneyOff(Voucher voucher, Basket basket, BasketVoucher basketVoucher)
        {
            decimal basketTotal = basket.BasketTotal();
            if (voucher.MinSpend < basketTotal )
            {
                basketVoucher.Value = voucher.Value *-1;
                basketVoucher.VoucherCode = voucher.VoucherCode;
                basketVoucher.VoucherDescription = voucher.VoucherDescription;
                basketVoucher.VoucherId = voucher.VoucherId;
                basket.AddBasketVoucher(basketVoucher);
            }

        }


        public void PercentOff(Voucher voucher, Basket basket, BasketVoucher basketVoucher)
        {
            if (voucher.MinSpend > basket.BasketTotal())
            {
                basketVoucher.Value = (voucher.Value * (basket.BasketTotal() / 100)) * -1;
                basketVoucher.VoucherCode = voucher.VoucherCode;
                basketVoucher.VoucherDescription = voucher.VoucherDescription;
                basketVoucher.VoucherId = voucher.VoucherId;
                basket.AddBasketVoucher(basketVoucher);
            }

           
        }
    }
}
