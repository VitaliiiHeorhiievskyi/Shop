using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IProduct
    {
        string Name { get; set; }

        double Weight { get; set; }

        double Price { get; set; }

        int ExpirationDate { get; set; }

        DateTime DateOfManufacture { get; set; }
    }
}
