using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public static class FileWorker
    {
        private static List<Product> Products { get; set; }


        public static ShopStorage ReadDataForStorage(string file)
        {
            ShopStorage shop = new ShopStorage();

            shop.ReadDataFromFile(file);

            return shop;
        }

        public static List<CreditCard> ReadDataForCreditCards(string file)
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            using (StreamReader reader = new StreamReader(file))
            {
                string data = reader.ReadToEnd();

                string[] lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                string[] words = null;
                foreach (var line in lines)
                {
                    words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (words.Length < 3)
                        continue;
                    else
                    {
                        creditCards.Add(new CreditCard(words[0], int.Parse(words[1]), double.Parse(words[2])));
                    }

                }

            }
            return creditCards;
        }

        public static List<User> ReadDataForUsers(string file)
        {
            List<User> Users = new List<User>();

            using (StreamReader reader = new StreamReader(file))
            {
                string data = reader.ReadToEnd();

                string[] lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                string[] words = null;

                User user = null;

                int temp = 4;

                for (int i = 0; i < lines.Length; i++)
                {
                    words = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (words.Length < 4)
                        continue;
                    else
                    {
                        switch (words[0])
                        {
                            case "Client":
                                user = new Client(words[1], words[2], words[3].Trim('\r'));
                                Users.Add(user);
                                temp = 4;
                                break;
                            case "VipClient":
                                user = new VipClient(words[1], words[2], words[3], int.Parse(words[4].Trim('\r')));
                                Users.Add(user);
                                temp = 5;
                                break;
                            case "Admin":
                                user = new Administrator(words[1], words[2], words[3].Trim('\r'));
                                Users.Add(user);
                                break;
                            case "Moderator":
                                user = new Moderator(words[1], words[2], words[3].Trim('\r'));
                                Users.Add(user);
                                break;
                        }
                    }
                    if (words.Length < 6)
                        continue;

                    while (true)
                    {
                        string dat = words[temp] + " " + words[temp + 1];
                        DateTime.TryParseExact(dat, "dd.MM.yyyy HH:mm:ss", new CultureInfo(3), DateTimeStyles.None, out DateTime date);
                        OrderStatus status = new OrderStatus();
                        switch (words[temp + 2])
                        {
                            case "New":
                                status = OrderStatus.New;
                                break;
                            case "InProcess":
                                status = OrderStatus.InProcess;
                                break;
                            case "InRoad":
                                status = OrderStatus.InRoad;
                                break;
                            case "Delievered":
                                status = OrderStatus.Delievered;
                                break;
                        }

                        Products = new List<Product>();

                        for (int j=0; j < int.Parse(words[temp + 5]);j++)
                        {
                            string[] worlds = lines[++i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            switch (worlds[0])
                            {
                                case "Product":
                                    AddProduct(lines[i]);
                                    break;
                                case "Meat":
                                    AddMeat(lines[i]);
                                    break;
                                case "Dairy":
                                    AddDairyProduct(lines[i]);
                                    break;
                            }
                        }
                        ((Client)user).Orders.Add(new Order((Client)user, date, status, double.Parse(words[temp + 4]), words[temp + 3], Products));

                        if (lines.Length <= i + 1)
                            break;

                        if (lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length != 6)
                            break;
                        temp = 0;
                        words = lines[++i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                   
                }
            }

            return Users;
        }

        public static void AddProduct(string data)
        {
            data = data.Substring(8);
            Product product = new Product();
            if (product.TryParse(data))
            {
                Products.Add(product);
            }
        }

        public static void AddMeat(string data)
        {
            data = data.Substring(5);
            Meat product = new Meat();
            if (product.TryParse(data))
            {
                Products.Add(product);
            }
        }

        public static void AddDairyProduct(string data)
        {
            data = data.Substring(6);
            DairyProduct product = new DairyProduct();
            if (product.TryParse(data))
            {
                Products.Add(product);
            }
        }

        public static void WriteDataForUsers(string file, List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                string data="";
                foreach (var user in users)
                {
                    if (user is Administrator)
                    {
                        data = $"Admin {user.Login} {user.Password} {user.Name.Trim('\r')}";
                        writer.WriteLine(data);
                        continue;
                    }
                    if (user is Moderator)
                    {
                        data = $"Moderator {user.Login} {user.Password} {user.Name.Trim('\r')}";
                        writer.WriteLine(data);
                        continue;
                    }
                    if (user is VipClient)
                    {
                        data = $"VipClient {user.Login} {user.Password} {user.Name.Trim('\r')} {((VipClient)user).Discount}";
                        if (((Client)user).Orders.Count == 0)
                        {
                            writer.WriteLine(data);
                            continue;
                        }
                    }
                    else if (user is Client)
                    {
                        data = $"Client {user.Login} {user.Password} {user.Name.Trim('\r')}";
                        if(((Client)user).Orders.Count==0)
                        {
                            writer.WriteLine(data);
                            continue;
                        }
                    }
                   
                    foreach (var order in ((Client)user).Orders)
                    {
                        data += $" {order.Date} {order.Status.ToString()} {order.Address} {order.TotalPrice} {order.Products.Count}";
                        writer.WriteLine(data);
                        foreach (var product in order.Products)
                        {
                            if (product is Meat)
                                data = "Meat ";
                            else if (product is DairyProduct)
                                data = "Dairy ";
                            else data = "Product ";

                            data += $"{product.Name} {product.Weight} {product.Price} {product.ExpirationDate} {product.DateOfManufacture.ToShortDateString()}";

                            if (product is Meat)
                            {
                                data += $" {((Meat)product).Category} {((Meat)product).Kind}";
                            }
                            writer.WriteLine(data);
                            data = "";
                        }
                    }
                }
            }

        }

        public static void WtiteDataForStorage(string file, List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                string data;
                foreach (var product in products)
                {
                    if (product is Meat)
                        data = "Meat ";
                    else if (product is DairyProduct)
                        data = "Dairy ";
                    else data = "Product ";

                    data += $"{product.Name} {product.Weight} {product.Price} {product.ExpirationDate} {product.DateOfManufacture.ToShortDateString()}";

                    if (product is Meat)
                    {
                        data += $" {((Meat)product).Category} {((Meat)product).Kind}";
                    }

                    writer.WriteLine(data);
                }
            }
        }

    }
}
