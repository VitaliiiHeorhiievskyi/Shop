using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Moderator:User
    {
        public Moderator(string login, string password, string name):base(login,password,name)
        {

        }

        public VipClient ChangeStatusToVip(Client client, int discount)
        {
            if (client == null)
                throw new ArgumentNullException();

            VipClient vip= new VipClient(client.Login, client.Password, client.Name, discount);

            vip.Orders = client.Orders;

            client = vip;

            return vip;
        }

        public Client ChangeStatusToSimple(Client client)
        {
            if (client == null)
                throw new ArgumentNullException();

            Client temp = new Client(client.Login, client.Password, client.Name);

            temp.Orders = client.Orders;

            client = temp;

            return temp;
        }
    }
}
