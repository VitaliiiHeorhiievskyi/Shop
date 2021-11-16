using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
   public class Bank
    {
        public List<CreditCard> Cards { get; set; }

        public Bank(List<CreditCard> cards)
        {
            Cards = cards;
        }

        public CreditCard FindCard(string id, int pin)
        {
            return Cards.Find(i => i.ID == id && i.Pin == pin);
        }
    }
}
