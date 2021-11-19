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
    public partial class FormEditProduct : Form
    {

        public static Product product;

        public static int index;
        public FormEditProduct()
        {
            InitializeComponent();

            ProductName.Text = product.Name;

            Price.Value = (decimal)product.Price;

            Weight.Value= (decimal)product.Weight;

            Expiration.Value= (decimal)product.ExpirationDate;

            Date.Value = product.DateOfManufacture;

            if (product is Meat)
                MeatR.Checked = true;
            else if (product is DairyProduct)
                DairyR.Checked = true;
            else ProductR.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            FormForAdmin.form.Show();
        }

        private void MeatR_CheckedChanged(object sender, EventArgs e)
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

        private void EditProduct_Click(object sender, EventArgs e)
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
                    Product editedProduct = new Product(name, weight, price, exp, date);

                    if (editedProduct.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Form1.shop.Storage.Products[index] = editedProduct;

                    MessageBox.Show("Product is edited!!", "Product is edited!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormForAdmin.form.Print();
                }
                else if (DairyR.Checked)
                {
                    Product editedProduct = new DairyProduct(name, weight, price, exp, date);

                    if (editedProduct.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Form1.shop.Storage.Products[index] = editedProduct;

                    MessageBox.Show("Product is edited!!", "Product is edited!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormForAdmin.form.Print();

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

                    Product editedProduct = new Meat(name, weight, price, exp, date, category, kind);

                    if (editedProduct.IsSpoiledProduct())
                    {
                        MessageBox.Show("Product is spoiled!!", "Product is spoiled!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Form1.shop.Storage.Products[index] = editedProduct;

                    MessageBox.Show("Product is edited!!", "Product is edited!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormForAdmin.form.Print();
                }
            }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
