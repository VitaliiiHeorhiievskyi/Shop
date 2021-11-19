using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IShopStorage
    {
        List<Product> Products { get;}


        bool AddProduct(string data);

        bool AddMeat(string data);

        bool AddDairyProduct(string data);

        bool AddProduct(Product product);

        bool AddMeat(Meat meat);

        bool AddDairyProduct(DairyProduct dairyProduct);


    }
}
