using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    interface IUser
    {
        string Login { get; set; }

        string Password { get; set; }

        string Name { get; set; }
    }
}
