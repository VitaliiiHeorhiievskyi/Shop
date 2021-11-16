using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public enum OrderStatus
    {
        New,
        InProcess,
        InRoad,
        Delievered
    }
    public class Order
    {
        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public OrderStatus Status { get; set; }

        public double TotalPrice { get; set; }

        private string address;

        public string Address
        {
            get { return address; }
            set 
            { 
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException("Adrress is empty!!");
                address = value;
            }
        }


        public List<Product> Products { get; set; }

        public int Discount { get; set; }

        public Order(Client client, List<Product> products, int discount=0)
        {
            Date = DateTime.Now;

            Status = OrderStatus.New;

            UserName = client.Name;

            Products = products;

            Discount = discount;

            TotalPrice = client.Basket.TotalPrice * (100 - discount) / 100;

            Address = "Not known";
        }

        public Order(Client client, DateTime date, OrderStatus status,double totalPrice,string address, List<Product> products)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException("Adrress is empty!!");


            Date = date;

            Status = status;

            TotalPrice = totalPrice;

            UserName = client.Name;

            Products = products;

            Address = address;
        }
    }
}
