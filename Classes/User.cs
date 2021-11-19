using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class User:IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public User(string login, string password, string name)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException(nameof(login), "Login is empty!!");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password), "Password is empty!!");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Password is empty!!");

            Login = login;

            Password = password;

            Name = name;
        }
    }
}
