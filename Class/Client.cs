using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Client:User
    {
        public ClientBasket Basket  { get; set; }

        public List<Order> Orders { get; set; }

        public Client(string login, string password, string name):base(login,password,name)
        {
            Basket = new ClientBasket();

            Orders = new List<Order>();
        }

        virtual public Order MakeOrder()
        {
            return new Order(this,Basket.Products);
        }
    }
}
