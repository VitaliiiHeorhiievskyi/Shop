using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CreditCard
    {
        public string ID { get; set; }

        public int Pin { get; }

        public double Money { get; set; }

        public CreditCard(string id,int pin, double money)
        {
            ID = id;

            Pin = pin;

            Money = money;
        }
    }
}
