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
    public partial class TheMobileShopPurchaseHistory : Form
    {
        public TheMobileShopPurchaseHistory()
        {
            InitializeComponent();
            this.Load += TheMobileShopPurchaseHistory_Load;
            this.Text = "The Mobile Shop Purchase History";
            buttonClose.Click += ButtonClose_Click;
        }

        private void TheMobileShopPurchaseHistory_Load(object sender, EventArgs e)
        {
            InitializeDataGridView<Transaction>(dataGridViewPurchases, "EmployeeId", "Employee", "TransactionProducts");
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void InitializeDataGridView<T>(DataGridView dataGridView, params string[] columnsToHide) where T : class
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
                new DataGridViewTextBoxColumn() { Name = "Price" },
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
                foreach (TransactionProduct item in context.TransactionProducts)
                {
                    string[] rowAdd =
                    {
                        item.Transaction.TransactionId.ToString(),
                        item.Transaction.Date.ToString(),
                        (item.Inventory.Price*item.Quantity).ToString("C"),
                        item.Inventory.Name,
                        item.Quantity.ToString(),
                        item.Discount.ToString(),
                        item.Transaction.Employee.FirstName.ToString()
                     };
                    
                    dataGridView.Rows.Add(rowAdd);
                }
            }
        }
    }
}

                        