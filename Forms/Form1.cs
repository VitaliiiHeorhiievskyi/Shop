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
    public partial class Form1 : Form
    {
        public static Shop shop;

        public static Bank bank;

        public static Form1 form1;

        public static ShopForm shopForm;

        public Form1()
        {
            InitializeComponent();

            shop = Shop.getInstance();

            form1 = this;

            shop.Users = FileWorker.ReadDataForUsers(@"D:\Users\vital\source\repos\Shop\users.txt");

            shop.Storage = FileWorker.ReadDataForStorage(@"D:\Users\vital\source\repos\Shop\Input.txt");

            bank = new Bank(FileWorker.ReadDataForCreditCards(@"D:\Users\vital\source\repos\Shop\Cards.txt"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string login = Login.Text;

                string password = Password.Text;

                User user = shop.UserLogIn(login, password);

                if (user == null)
                {
                    throw new ArgumentException("User not found!!\nMaybe you are not registered !!");
                }
                else if (user is VipClient)
                {
                    ShopForm.client = (VipClient)user;

                    shopForm = new ShopForm();

                    shopForm.Show();

                    Hide();
                }
                else if (user is Client)
                {
                    ShopForm.client = (Client)user;

                    shopForm = new ShopForm();

                    shopForm.Show();

                    Hide();
                }
                else if (user is Administrator)
                {
                    FormForAdmin.administrator = (Administrator)user;

                    FormForAdmin formForAdmin = new FormForAdmin();

                    formForAdmin.Show();

                    Hide();
                }
                else if (user is Moderator)
                {
                    FormForModerator.clients = new List<Client>();

                    FormForModerator.moderator= (Moderator)user;

                    foreach (var client in shop.Users.FindAll(i => i is Client))
                    {
                        FormForModerator.clients.Add((Client)client);
                    }

                    FormForModerator formForModerator = new FormForModerator();

                    formForModerator.Show();

                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();

            checkIn.Show();

            Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileWorker.WriteDataForUsers(@"D:\Users\vital\source\repos\Shop\users.txt",shop.Users);

            FileWorker.WtiteDataForStorage(@"D:\Users\vital\source\repos\Shop\Input.txt", shop.Storage.Products);
        }
    }
}
