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
    public partial class OrderForm : Form
    {
        public static Order order;

        public static OrderForm orderForm;
        public OrderForm()
        {
            InitializeComponent();

            ClientName.Text = order.UserName;

            Price.Text = order.TotalPrice.ToString();

            Date.Text = order.Date.ToShortDateString();

            Status.Text = order.Status.ToString();

            orderForm = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                order.Address = Adrress.Text;

                CreditCardForm cardForm = new CreditCardForm();

                cardForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Basket.basket.Show();
        }

    }
}
