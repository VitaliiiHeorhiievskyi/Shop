using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Basket : Form
    {
        public static Client client;

        public static Basket basket;

        public static ShopForm shopForm;
        public Basket()
        {
            InitializeComponent();
            Print();

            ShopForm.basket = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product;

            if (dataGridView1.CurrentRow == null)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            double price = (double)dataGridView1.CurrentRow.Cells[2].Value;

            product = client.Basket.Products.Find(i => i.Name == name && i.Price == price);

            if (product != null)
            {
                client.Basket.RemoveProduct(product);
            }

            Form1.shop.Storage.Products.Add(product);

            Print();

            shopForm.Print();
        }

        public void Print()
        {
            if (dataGridView1.Columns.Count == 0)
                return;


            dataGridView1.Rows.Clear();

            foreach (var product in client.Basket.Products)
            {
                if (product is Meat)
                    dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category);
                else if (product is DairyProduct) dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");
                else dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client.Basket.Products.Count == 0)
            {
                MessageBox.Show("Basket is empty!!!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                

            Order order=client.MakeOrder();

            OrderForm.order = order;

            OrderForm orderForm = new OrderForm();

            orderForm.Show();

            basket = this;

            this.Hide();
        }
    }
}
