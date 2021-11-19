using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Shop
    {
        private static Shop instance;

        private Shop()
        {
            Users = new List<User>();

            Storage = new ShopStorage();
        }

        public static Shop getInstance()
        {
            if (instance == null)
                instance = new Shop();
            return instance;
        }

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

    }
}
