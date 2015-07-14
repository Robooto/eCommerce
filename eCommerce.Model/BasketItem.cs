using eCommerce.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class BasketItem : IBasketItem
    {
        private Product _product;

        public int BasketItemId { get; set; }
        public Guid BasketId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual IProduct IProduct { get { return _product as IProduct; } set { _product = value as Product; } }
        public virtual Product Product { get { return _product; } set { _product = value; } }
    }
}
