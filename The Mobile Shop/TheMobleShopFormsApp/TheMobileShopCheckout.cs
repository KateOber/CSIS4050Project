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
        public TheMobileShopCheckout(List<TransactionProduct> addedItemList)
        {
            InitializeComponent();

            this.Load += (s,e) => TheMobileShopCheckout_Load(addedItemList);
            this.Text = "The Mobile Shop Checkout";
            buttonBack.Click += ButtonBack_Click;
        }

        private void TheMobileShopCheckout_Load(List<TransactionProduct> recentTransactions)
        {
            InitializeDataGridView(dataGridViewItems, recentTransactions);
        }
        private void InitializeDataGridView(DataGridView dataGridView, List<TransactionProduct> recentTransactions)
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
                // loop through 
                foreach (TransactionProduct item in recentTransactions)
                {
                    string[] rowAdd =
                    {
                        item.Transaction.TransactionId.ToString(),
                        item.Transaction.Date.ToString(),
                        item.Transaction.TotalPrice.ToString(),
                        item.Inventory.Name,
                        item.Quantity.ToString(),
                        item.Discount.ToString(),
                        item.Transaction.EmployeeId.ToString()
                     };
                    dataGridView.Rows.Add(rowAdd);
                }
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
