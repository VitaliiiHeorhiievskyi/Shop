using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Shop
{
    public partial class FormForAdmin : Form
    {
        public static Administrator administrator;

        public static FormForAdmin form;

        public FormForAdmin()
        {
            InitializeComponent();

            UserName.Text = administrator.Name;

            Print();

            form = this;

        }

        public void Print()
        {
            dataGridView1.Rows.Clear();

            foreach (var product in Form1.shop.Storage.Products)
            {
                if (product is Meat)
                    dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category,"Edit");
                else if (product is DairyProduct) dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-", "Edit");
                else dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-", "Edit");

            }

        }

        private void Info_Click(object sender, EventArgs e)
        {

        }

        private void FormForAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            double price = (double)dataGridView1.CurrentRow.Cells[2].Value;

            int row = Form1.shop.Storage.Products.FindIndex(i => i.Name == name && i.Price == price);

            if (System.Windows.MessageBox.Show("Are you sure?", "Delete product", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
            {
                administrator.RemoveProduct(Form1.shop.Storage, Form1.shop.Storage.Products[row]);
                Print();
            }
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct addProduct = new FormAddProduct();

            addProduct.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            if (dataGridView1.CurrentCellAddress.X != 8)
                return;

            string name = (string)dataGridView1.CurrentRow.Cells[1].Value;

            double price = (double)dataGridView1.CurrentRow.Cells[2].Value;

            int row = Form1.shop.Storage.Products.FindIndex(i => i.Name == name && i.Price == price);

            FormEditProduct.product = Form1.shop.Storage.Products[row];

            FormEditProduct.index = row;

            FormEditProduct formEdit = new FormEditProduct();

            formEdit.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string search = textBox1.Text;


            foreach (var product in Form1.shop.Storage.Products.FindAll(i => i.Name.Contains(search)))
            {
                if (product is Meat)
                    dataGridView1.Rows.Add("Meat", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), (product as Meat).Kind, (product as Meat).Category,"Edit");
                else if (product is DairyProduct) dataGridView1.Rows.Add("Dairy", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-","Edit");
                else dataGridView1.Rows.Add("Product", product.Name, product.Price, product.Weight, product.ExpirationDate, product.DateOfManufacture.ToShortDateString(), "-", "-","Edit");

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
