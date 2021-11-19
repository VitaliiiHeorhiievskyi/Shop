using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Shop
{
    //public delegate void PrintMessageHandler(string message);
    //public delegate void PrintIncorrect(string path, string wrongLine, int paramCounter);
    //public delegate void ModifyInput(ShopStorage storage, string wrongLine);
    //public delegate void RemoveSpoiledProductsAndWriteInLog(List<Product> products, string path);

    public class ShopStorage:IShopStorage
    {
        //public event PrintMessageHandler OnAdd;
        //public event PrintIncorrect OnWrongInput;
        //public event ModifyInput OnCorrectWrongInputForProduct;
        //public event ModifyInput OnCorrectWrongInputForMeat;
        //public event ModifyInput OnCorrectWrongInputForDairy;
        //public event RemoveSpoiledProductsAndWriteInLog OnRemoveSpoiledProducts;

        public List<Product> Products { get; private set; }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < Products.Count)
                    return Products[index];
                else throw new ArgumentNullException("Going beyond the array");
            }

            set
            {
                if (index >= 0 && index < Products.Count && value is Product)
                    Products[index] = (Product)value;
                else throw new ArgumentNullException("Going beyond the array");
            }
        }

        public ShopStorage(List<Product> products)
        {
            Products = new List<Product>(products);
        }

        public ShopStorage()
        {
            Products = new List<Product>();
        }

        public override string ToString()
        {
            string res = "";
            foreach (var product in Products)
            {
                res += product;
            }
            return res;
        }

        public void ReadDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            string[] data;

            using (StreamReader reader = new StreamReader(filePath))
            {
                data = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in data)
            {
                string[] worlds = item.Split();
                switch (worlds[0])
                {
                    case "Product":
                        AddProduct(item);
                        break;
                    case "Meat":
                        AddMeat(item);
                        break;
                    case "Dairy":
                        AddDairyProduct(item);
                        break;
                    default:
                        //OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", item, 0);
                        break;
                }

            }

        }

        public bool AddProduct(string data)
        {
            data = data.Substring(8);
            Product product = new Product();
            //product.OnWrongInput += OnWrongInput.Invoke;
            if (product.TryParse(data))
            {
                Products.Add(product);
                //OnAdd?.Invoke("Product was added");
                return true;
            }
            else
            {
                //OnCorrectWrongInputForProduct?.Invoke(this, data);
                return false;
            }
        }

        public bool AddMeat(string data)
        {
            data = data.Substring(5);
            Meat product = new Meat();
            //product.OnWrongInput += OnWrongInput.Invoke;
            if (product.TryParse(data))
            {
                Products.Add(product);
                //OnAdd?.Invoke("Meat was added");
                return true;
            }
            else
            {
                //OnCorrectWrongInputForMeat?.Invoke(this, data);
                return false;
            }
        }

        public bool AddDairyProduct(string data)
        {
            data = data.Substring(6);
            DairyProduct product = new DairyProduct();
            //product.OnWrongInput += OnWrongInput.Invoke;
            if (product.TryParse(data))
            {
                Products.Add(product);
                //OnAdd?.Invoke("Dairy product was added");
                return true;
            }
            else
            {
                //OnCorrectWrongInputForDairy?.Invoke(this, data);
                return false;
            }
        }

        public bool AddProduct(Product product)
        {
            if (product!=null||!product.IsSpoiledProduct())
            {
                Products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddMeat(Meat meat)
        {
            if (meat != null || !meat.IsSpoiledProduct())
            {
                Products.Add(meat);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDairyProduct(DairyProduct dairyProduct)
        {
            if (dairyProduct != null || !dairyProduct.IsSpoiledProduct())
            {
                Products.Add(dairyProduct);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
