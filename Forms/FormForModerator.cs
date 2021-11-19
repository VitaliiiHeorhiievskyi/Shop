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

    public partial class FormForModerator : Form
    {

        public static List<Client> clients;

        public static Moderator moderator;
        public FormForModerator()
        {
            InitializeComponent();

            ((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).Items.Add("Client");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[0]).Items.Add("VipClient");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).Items.Add("0");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).Items.Add("5");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).Items.Add("10");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).Items.Add("15");
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).Items.Add("20");
            PrintClients();

            UserName.Text = moderator.Name;
        }

        public void PrintClients()
        {
            foreach (var client in clients)
            {
                if (client is VipClient)
                    dataGridView1.Rows.Add("VipClient", client.Name, ((VipClient)client).Discount.ToString(), "Orders");
                else dataGridView1.Rows.Add("Client", client.Name, "0", "Orders");
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            int row = clients.FindIndex(i => i.Name == name);

            if (e.ColumnIndex == 0)
            {
                Client temp = clients[row];

                int index = Form1.shop.Users.FindIndex(i => (i.Name == temp.Name && i.Login == temp.Login));

                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Client")
                {
                    clients[row] =moderator.ChangeStatusToSimple(clients[row]);

                    dataGridView1.CurrentRow.Cells[2].Value = "0";
                }
                else clients[row] =moderator.ChangeStatusToVip(clients[row], 0);

               Form1.shop.Users[index] = clients[row];
            }
            else if (e.ColumnIndex == 2)
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Client")
                {
                    MessageBox.Show("You cannot change the discount!!!\nIt is a simple Client.", "Be carefull!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dataGridView1.CurrentRow.Cells[2].Value = "0";
                    return;
                }
                else
                {
                    VipClient temp = (VipClient)clients[row];

                    int index = Form1.shop.Users.FindIndex(i => (i.Name == temp.Name && i.Login == temp.Login));

                    ((VipClient)Form1.shop.Users[index]).Discount = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());

                    clients[row] = ((Client)Form1.shop.Users[index]);

                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            if (e.ColumnIndex != 3)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            int row = clients.FindIndex(i => i.Name == name);

            FormForEditOrder.index = row;

            FormForEditOrder.client = clients[row];

            FormForEditOrder editOrder = new FormForEditOrder();

            editOrder.Show();
        }

        private void FormForModerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string search = textBox1.Text;

            foreach (var client in clients.FindAll(i => i.Name.Contains(search))) 
            {
                if (client is VipClient)
                    dataGridView1.Rows.Add("VipClient", client.Name, ((VipClient)client).Discount.ToString(), "Orders");
                else dataGridView1.Rows.Add("Client", client.Name, "0", "Orders");
            }
        }
    }
}
