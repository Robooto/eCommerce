using eCommerce.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Basket : IBasket
    {
        private List<BasketItem> _basketItems;
        private List<BasketVoucher> _basketVouchers;

        public Guid BasketId { get; set; }
        public DateTime date { get; set; }

        public Basket() {
            this.BasketItems = new List<BasketItem>();
            this.BasketVouchers = new List<BasketVoucher>();
        }

        public decimal BasketTotal() {
            decimal? total = (from item in BasketItems
                              select (int?)item.Quantity * item.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public decimal BasketItemCount() {
            return _basketItems.Count();
        }


        public virtual ICollection<IBasketItem> IBasketItems { get { return _basketItems.ConvertAll(i => (IBasketItem)i); } }
        public virtual ICollection<BasketItem> BasketItems  { get { return _basketItems; } set { _basketItems = value.ToList(); } }

        public virtual ICollection<IBasketVoucher> IBasketVouchers { get { return _basketVouchers.ConvertAll(i => (IBasketVoucher)i); } }
        public virtual ICollection<BasketVoucher> BasketVouchers { get { return _basketVouchers; } set { _basketVouchers = value.ToList(); } }

        public void AddBasketItem(IBasketItem item)
        {
            _basketItems.Add((BasketItem)item);
        }

        public void AddBasketVoucher(IBasketVoucher voucher) { 
            _basketVouchers.Add((BasketVoucher) voucher);
        }
    }
}
