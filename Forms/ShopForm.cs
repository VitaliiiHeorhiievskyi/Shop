using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Shop
{
    public partial class ShopForm : Form
    {
        public static Client client;

        public static Basket basket;
        public ShopForm()
        {
            InitializeComponent();

            Print();

            UserName.Text = client.Name;

            if (client is VipClient)
            {
                Discount.Text += ((VipClient)client).Discount + "%";

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));

                Orders.Image= Image.FromFile(@"D:\Users\vital\source\repos\Shop\Images\VipClient.jpg");
            }
            else Discount.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Basket.client = client;

            Basket.shopForm = this;

            Basket basket = new Basket();

            basket.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string search = textBox1.Text;


            foreach (var product in Form1.shop.Storage.Products.FindAll(i => i.Name.Contains(search)))
            {
                if (product is Meat)
                    dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category);
                else if (product is DairyProduct) dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");
                else dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");

            }

        }

        public void Print()
        {
            dataGridView1.Rows.Clear();

            foreach (var product in Form1.shop.Storage.Products)
            {
                if (product is Meat)
                    dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category);
                else if (product is DairyProduct) dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");
                else dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");

            }

        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product;

            if (dataGridView1.CurrentRow == null)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            double price = (double)dataGridView1.CurrentRow.Cells[2].Value;

            product = Form1.shop.Storage.Products.Find(i => i.Name == name && i.Price == price);

            if (product != null)
            {
                Form1.shop.Storage.Products.Remove(Form1.shop.Storage.Products.Find(i => i.Name == name && i.Price == price));
            }

            client.Basket.AddProduct(product);

            Print();

            if (basket != null)
                basket.Print();

            //Close();
        }

        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in client.Basket.Products)
            {
                Form1.shop.Storage.Products.Add(item);
            }
            Form1.form1.Show();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            FormOrders formOrders = new FormOrders();

            foreach (var order in client.Orders)
            {
                formOrders.dataGridView1.Rows.Add(order.Date, order.TotalPrice+" UAH", order.Address, order.Status,"Show products");
            }

            formOrders.Show();
        }
    }
}
