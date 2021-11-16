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
    public partial class CreditCardForm : Form
    {
        public CreditCardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ID.Text))
            {
                MessageBox.Show("The ID field is empty!!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string id = ID.Text;
            if(string.IsNullOrEmpty(Pin.Text))
            {
                MessageBox.Show("The PIN field is empty!!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int pin = int.Parse(Pin.Text);

            CreditCard card= Form1.bank.FindCard(id, pin);

            if (card == null)
            {
                MessageBox.Show("Card not found!!!", "Card not found!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (card.Money < OrderForm.order.TotalPrice)
            {
                MessageBox.Show("Money not enough!!!", "Money!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                OrderForm.order.Products = new List<Product>(Basket.client.Basket.Products);
                card.Money -= OrderForm.order.TotalPrice;
                Basket.client.Orders.Add(OrderForm.order);
                MessageBox.Show("Operations is completed!!!", "Good!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OrderForm.orderForm.Close();
                Basket.client.Basket.Products.Clear();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            OrderForm.orderForm.Show();
        }
    }
}
