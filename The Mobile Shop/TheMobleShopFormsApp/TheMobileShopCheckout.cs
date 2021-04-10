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

            this.Load += (s, e) => TheMobileShopCheckout_Load(addedItemList);
            this.Text = "The Mobile Shop Checkout";
            buttonBack.Click += ButtonBack_Click;
        }
        /// <summary>
        /// loading data into datagrid view om load
        /// </summary>
        /// <param name="recentTransactions"></param>
        private void TheMobileShopCheckout_Load(List<TransactionProduct> recentTransactions)
        {
            InitializeDataGridView(dataGridViewItems, recentTransactions);
        }
        /// <summary>
        /// Initialize and populate data into gridview
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="recentTransactions"></param>
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
                new DataGridViewTextBoxColumn() { Name = "Product" },
                new DataGridViewTextBoxColumn() { Name = "Quantity" },
                new DataGridViewTextBoxColumn() { Name = "Total Price" },
                new DataGridViewTextBoxColumn() { Name = "Discount" }
          };

            dataGridView.Columns.AddRange(dataGridColumns);

            int totalQty = 0;
            double? totalDiscount = 0.0;
            double subTotal = 0.0;
            // unit-of-work context
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                // loop through 
                foreach (TransactionProduct item in recentTransactions)
                {
                    string[] rowAdd =
                    {
                        item.Inventory.Name,
                        item.Quantity.ToString(),
                        item.Inventory.Price.ToString(),
                        item.Discount.ToString()
                    };
                    totalQty += item.Quantity;
                    subTotal += item.Inventory.Price * item.Quantity;
                    totalDiscount += item.Discount;
                    dataGridView.Rows.Add(rowAdd);
                }
            }
            // calculate and show data into view fields.
            double tax = subTotal * 0.12;
            double? total = subTotal + tax - totalDiscount;
            labelSubTotal.Text =  subTotal.ToString("C");   
            labelDiscount.Text =  "$ "+Convert.ToString(totalDiscount);
            labelTotalNoOfItems.Text = totalQty + " Items";
            labelTax.Text =  tax.ToString("C");
            labelTotal.Text = total.HasValue? total.Value.ToString("C"):"$ 0.0";
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}