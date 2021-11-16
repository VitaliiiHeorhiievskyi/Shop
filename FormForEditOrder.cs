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
    public partial class FormForEditOrder : Form
    {
        public static Client client;

        public static int index;
        public FormForEditOrder()
        {
            InitializeComponent();

            ((DataGridViewComboBoxColumn)dataGridView1.Columns[3]).Items.Add("New");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[3]).Items.Add("InProcess");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[3]).Items.Add("InRoad");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[3]).Items.Add("Delievered");
            PrintOrders();
        }

        public void PrintOrders()
        {
            foreach (var order in client.Orders)
            {
                dataGridView1.Rows.Add(order.Date.ToShortDateString(), order.TotalPrice, order.Address, order.Status.ToString(), "Products");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
                return;

            int row = e.RowIndex;

            switch (dataGridView1.CurrentCell.Value.ToString())
            {
                case "New":
                    client.Orders[row].Status = OrderStatus.New;
                    break;
                case "InRoad":
                    client.Orders[row].Status = OrderStatus.InRoad;
                    break;
                case "InProcess":
                    client.Orders[row].Status = OrderStatus.InProcess;
                    break;
                case "Delievered":
                    client.Orders[row].Status = OrderStatus.Delievered;
                    break;
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
                return;

            Order order = client.Orders[e.RowIndex];

            FormProducts form = new FormProducts();

            foreach (var product in order.Products)
            {
                if (product is Meat)
                    form.dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category);
                else if (product is DairyProduct) form.dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");
                else form.dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-");

            }

            form.Show();
        }

        private void FormForEditOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormForModerator.clients[index] = client;

            int count = Form1.shop.Users.FindIndex(i => (i.Name == client.Name && i.Login == client.Login));

            Form1.shop.Users[count] = client;
        }
    }
}
