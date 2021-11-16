using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class VipClient:Client
    {
        public int Discount { get; set; }
        public VipClient(string login, string password, string name, int discount) :base(login,password,name)
        {
            Discount = discount;
        }

        public override Order MakeOrder()
        {
            return new Order(this, Basket.Products, Discount);
        }
    }
}
