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
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (MeatR.Checked)
            {
                CategoryG.Enabled = true;
                KindG.Enabled = true;
            }
            else 
            {
                CategoryG.Enabled = false;
                KindG.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ProductName.Text;

                double price = (double)Price.Value;

                double weight = (double)Weight.Value;

                int exp = (int)Expiration.Value;

                DateTime date = Date.Value;

                if (ProductR.Checked)
                {
                    Product product = new Product(name, weight, price, exp, date);

                    if (product.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    FormForAdmin.administrator.AddProduct(Form1.shop.Storage, product);

                    MessageBox.Show("Product is added!!", "Product is added!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormForAdmin.form.Print();
                }
                else if (DairyR.Checked)
                {
                    Product product = new DairyProduct(name, weight, price, exp, date);

                    if (product.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    FormForAdmin.administrator.AddProduct(Form1.shop.Storage, product);

                    FormForAdmin.form.Print();

                    MessageBox.Show("Product is added!!", "Product is added!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (MeatR.Checked)
                {
                    Category category = 0;

                    Kind kind = 0;

                    if (First.Checked)
                        category = Category.FirstSort;
                    else if (SecondSort.Checked)
                        category = Category.FirstSort;
                    else category = Category.HighSort;

                    if (Pork.Checked)
                        kind = Kind.Pork;
                    else if (Mutton.Checked)
                        kind = Kind.Mutton;
                    else if (Veal.Checked)
                        kind = Kind.Veal;
                    else kind = Kind.Chicken;

                    Product product = new Meat(name, weight, price, exp, date, category, kind);

                    if (product.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    FormForAdmin.administrator.AddProduct(Form1.shop.Storage, product);

                    FormForAdmin.form.Print();

                    MessageBox.Show("Product is added!!", "Product is added!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormForAdmin.form.Show();
        }
    }
}
