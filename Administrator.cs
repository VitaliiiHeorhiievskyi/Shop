using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Administrator:User
    {
        public Administrator(string login, string password, string name):base(login,password,name)
        {

        }

        public void AddProduct(ShopStorage storage, Product product)
        {
            if (storage == null || product == null)
                throw new ArgumentNullException();

            storage.Products.Add(product);
        }

        public bool RemoveProduct(ShopStorage storage, Product product)
        {
            if (storage == null || product == null)
                throw new ArgumentNullException();

            return storage.Products.Remove(product);
        }

        
    }
}
