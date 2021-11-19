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
    public partial class CheckIn : Form
    {
        public CheckIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string login = Login.Text;

                string password = Password.Text;

                string name = UserName.Text;

                if (string.IsNullOrEmpty(login))
                {
                    throw new ArgumentException("Login is empty!!!");
                }
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Password is empty!!!");
                }
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name is empty!!!");
                }

                if (Form1.shop.Users.Find(i => i.Login == login) != null)
                {
                    MessageBox.Show("This login is busy!!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Form1.shop.AddUser(new Client(login, password, name));

                Form1.form1.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CheckIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form1.Show();
        }
    }
}
