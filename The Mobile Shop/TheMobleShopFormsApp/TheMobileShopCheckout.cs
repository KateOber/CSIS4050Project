using EFControllerUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheMobileShopCodeFirstFromDB;

namespace TheMobleShopFormsApp
{
    public partial class TheMobileShopCheckout : Form
    {
        public TheMobileShopCheckout()
        {
            InitializeComponent();

            this.Load += TheMobileShopCheckout_Load;
            this.Text = "The Mobile Shop Checkout";
            buttonBack.Click += ButtonBack_Click;
        }

        private void TheMobileShopCheckout_Load(object sender, EventArgs e)
        {
            InitializeDataGridView(dataGridViewItems);
        }
        private void InitializeDataGridView(DataGridView dataGridView)
        {
            // Allow users to add/delete rows, and fill out columns to the entire width of the control
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView.Columns.Clear();

            DataGridViewTextBoxColumn[] dataGridColumns = new DataGridViewTextBoxColumn[]
          {
                new DataGridViewTextBoxColumn() { Name = "ID"},
                new DataGridViewTextBoxColumn() { Name = "Date" },
                new DataGridViewTextBoxColumn() { Name = "Total Price" },
                new DataGridViewTextBoxColumn() { Name = "Product" },
                new DataGridViewTextBoxColumn() { Name = "Quantity" },
                new DataGridViewTextBoxColumn() { Name = "Discount" },
                new DataGridViewTextBoxColumn() { Name = "Sold By" },
          };

            dataGridView.Columns.AddRange(dataGridColumns);



            // unit-of-work context
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {

                Transaction recentTransaction = context.Transactions.Find(1);
                TransactionProduct item = context.TransactionProducts.Find(recentTransaction);
                // loop through 
               
                    string[] rowAdd =
                    {
                        item.Transaction.TransactionId.ToString(),
                        item.Transaction.Date.ToString(),
                        item.Transaction.TotalPrice.ToString(),
                        item.Inventory.Name,
                        item.Quantity.ToString(),
                        item.Discount.ToString(),
                        item.Transaction.Employee.FirstName.ToString()
                     };
                    dataGridView.Rows.Add(rowAdd);
                
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
