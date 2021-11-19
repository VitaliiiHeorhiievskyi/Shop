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
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
                return;

            Order order = ShopForm.client.Orders[e.RowIndex];

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
    }
}
