using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ClientBasket
    {
        public List<Product> Products { get; set; }

        public double TotalPrice 
        { 
            get 
            {
                double total=0;
                foreach (var product in Products)
                {
                    total += product.Price;
                }
                return total;
            } 
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        public ClientBasket()
        {
            Products = new List<Product>();
        }
    }
}
