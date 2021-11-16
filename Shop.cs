using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Shop
    {
        public List<User> Users { get; set; }

        public ShopStorage Storage { get; set; }

        public User UserLogIn(string login, string password)
        {
            return Users.Find(i => (i.Login == login && i.Password == password));
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            Users.Add(user);
        }

        public Shop()
        {
            Users = new List<User>();

            Storage = new ShopStorage();
        }
    }
}
