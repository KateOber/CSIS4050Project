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
using System.Data.Entity;
using EFControllerUtilities;
using System.Diagnostics;
using TheMobileShopValidation;

namespace TheMobleShopFormsApp
{
    //add button for seedDatabase

    public partial class TheMobileShopMainForm : Form
    {
        List<ItemQuantity> cart = new List<ItemQuantity>();

        double tax = 0;
        double total = 0;
        public TheMobileShopMainForm()
        {
            InitializeComponent();

            this.Text = "The Mobile Shop";

            // InitializeInventoryView(dataGridViewInventory);
            this.Load += (s, e) => TheMobileShopMainForm_Load();


            buttonInventory.Click += ButtonInventory_Click;
            buttonCheckout.Click += ButtonCheckout_Click;
            buttonSearch.Click += ButtonSearch_Click;
            buttonAddItem.Click += ButtonAddItem_Click;
            buttonAdminDashboard.Click += ButtonAdminDashboard_Click;
            buttonLogout.Click += ButtonLogout_Click;
            buttonPurchaseHistory.Click += ButtonPurchaseHistory_Click;
            buttonReset.Click += ButtonReset_Click;
            buttonRemoveItem.Click += ButtonRemoveItem_Click;

        }

        private void ButtonRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count >= 1)
            {
               
                    if (dataGridViewCart.SelectedCells.Count > 0)
                    {
                        string idtest = dataGridViewCart.SelectedCells[0].Value.ToString();
                        Debug.WriteLine("CELL VALUE FROM DATAGRIDDDDDDD "+idtest);
                        
                    }
                
            }

                
        }

        /// <summary>
        /// Resets Items in Inventory DataGridView
        /// And clears all textBoxes + unselects Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            //reset Inventory DataGrid
            TheMobileShopEntities context = new TheMobileShopEntities();
            ReloadDataGridView(context);
            //reset all textBoxes and listBox
            textBoxBrand.Clear();
            textBoxName.Clear();
            textBoxPriceMin.Clear();
            textBoxPriceMax.Clear();
            listBoxCategory.SelectedIndex = -1;
        }
        /// <summary>
        /// Opens Purchase History Form and Hides current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPurchaseHistory_Click(object sender, EventArgs e)
        {
            TheMobileShopPurchaseHistory purchaseHistoryForm = new TheMobileShopPurchaseHistory();
            OpenAndHideForm(purchaseHistoryForm);
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();

        }

        private void TheMobileShopMainForm_Load()
        {
            InitializeDataGridView<Inventory>(dataGridViewInventory, "ProductId", "Cost", "Description", "Category", "TransactionProducts");
            InitializeCartView(dataGridViewCart);
            GetEmployeeInfo();
            InitializePaymentListBox();

            foreach (Category cat in Controller<TheMobileShopEntities, Category>.GetEntities())
            {
                listBoxCategory.Items.Add(cat.CategoryName);
            }


        }
        /// <summary>
        /// Hides current form, Opens child form
        /// Shows current form once child form
        /// Returns OK dialog (closes)
        /// </summary>
        /// <param name="form"></param>
        public void OpenAndHideForm(Form form)
        {
            this.Hide();
            var formDialog = form.ShowDialog();
            if (formDialog == DialogResult.OK)
            {
                form.Hide();
                this.Show();
            }

        }
        /// <summary>
        /// Setup values in payment method listBox
        /// </summary>
        public void InitializePaymentListBox()
        {
            
            List<string> paymentMethods = new List<string>
            {
                "Cash",
                "MasterCard",
                "Visa",
                "AmericanExpress"
            };
            foreach (string m in paymentMethods)
                listBoxPaymentMethod.Items.Add(m);
        }
        private void ButtonAdminDashboard_Click(object sender, EventArgs e)
        {
            TheMobileShopAdminForm AdminForm = new TheMobileShopAdminForm();
            OpenAndHideForm(AdminForm);
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            AddItemsToCart();

        }
        private void AddItemsToCart()
        {
            if (dataGridViewInventory.SelectedRows.Count >= 1)
            {
                using (TheMobileShopEntities context = new TheMobileShopEntities())
                {
                    //Get selected rows from Inventory DataGridView
                    foreach (DataGridViewRow row in dataGridViewInventory.SelectedRows)
                    {
                        //if it's an inventory item
                        if (row.DataBoundItem is Inventory product)
                        {
                            //find the item in the Database (context)
                            Inventory itemFromContext = context.Inventories.Find(product.ProductId);
                            
                            //flag for if selected item already in cart
                            bool itemAlreadyInCart = false;
                            //if cart is empty add found item and set quantity as 1
                            if (cart.Count == 0)
                            {
                                cart.Add(new ItemQuantity { Inventory = itemFromContext, quantity = 1 });
                            }
                            //if cart not empty check if found item already in cart
                            else
                            {
                                for (int x = 0; x < cart.Count; x++)
                                {
                                    //item already in cart so increase quantity by 1 and set up flag
                                    if (itemFromContext.ProductId == cart[x].Inventory.ProductId)
                                    {
                                        cart[x].quantity++;
                                        itemAlreadyInCart = true;
                                    }
                                //if item not in cart add it with quantity 1
                                }
                                if (!itemAlreadyInCart)
                                {
                                    cart.Add(new ItemQuantity { Inventory = itemFromContext, quantity = 1 });
                                }
                            }
                            //Subtract item quantity from inventory and save context
                            itemFromContext.Quantity--;
                            context.SaveChanges();
                        }
                    }
                    //reload Cart and Inventory DataGridView
                    ReloadDataGridView(context);
                }


            }

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            


            string brand = textBoxBrand.Text.Trim();
            string name = textBoxName.Text.Trim().ToLower();
            bool boolPriceMin = Double.TryParse(textBoxPriceMin.Text, out double priceMin);
            bool boolPriceMax = Double.TryParse(textBoxPriceMax.Text, out double priceMax);
            string cat = "";
            int catId = 0;
            if (listBoxCategory.SelectedIndex != -1)
            {
                cat = listBoxCategory.SelectedItem.ToString();
                TheMobileShopEntities context = new TheMobileShopEntities();
                var categ = context.Categories.Where(c => c.CategoryName == cat).Single();
                catId = categ.CategoryId;
            }


            BindingList<Inventory> test = Controller<TheMobileShopEntities, Inventory>.SetBindingList();
            foreach (var item in test)
                Debug.WriteLine("ITEM IN LIST2 " + item);
            //var listFromSearch = test
            //    .Select(c => c.Name.ToLower().Contains(name));
            var listFromSearch = from item in test
                                 where item.Name.ToLower().Contains(name)
                                 select item;


            Debug.WriteLine("THIS MAMY ITEMS " + test.Count);
            for (int x = test.Count-1; x >= 0 ; x--)
            {
                string t = test[x].CategoryId.ToString();
                if (name != "")
                {
                if (!(test[x].Name.ToLower().Contains(name)))
                    test.Remove(test[x]);
                }
                if(brand != "")
                {
                    if (!(test[x].Brand.ToLower().Contains(brand)))
                        test.Remove(test[x]);
                }
                if (catId != 0)
                {
                    if (test[x].CategoryId != catId)
                        test.Remove(test[x]);
                }
                if(priceMin != 0)
                {
                    if (test[x].Price < priceMin)
                        test.Remove(test[x]);
                }
                if (priceMax != 0)
                {
                    if (test[x].Price > priceMax)
                        test.Remove(test[x]);
                }
            }
            Debug.WriteLine("SEARCH PRESSED, ITEM NAME " + test.Count);
            dataGridViewInventory.DataSource = test;
            dataGridViewInventory.Refresh();

        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
            //TheMobileShopEntities context = new TheMobileShopEntities();
            double totalCost = 0;
            foreach (ItemQuantity item in cart)
            {
                totalCost += item.Inventory.Cost * item.quantity;
            }

            Transaction newTransaction = new Transaction()
            {
                TotalPrice = total,
                TaxAmount = tax,
                TotalDiscount = 0,
                EmployeeId = TheMobileShopLogin.loggedInEmployee.EmployeeId,
                Date = DateTime.Now,
                PaymentMethod = listBoxPaymentMethod.SelectedItem.ToString(),
                TotalCost = totalCost,
            };

            Debug.WriteLine("TEST " + newTransaction.TotalPrice + newTransaction.PaymentMethod + newTransaction.TaxAmount);

            //context.Transactions.Add(newTransaction);
            //context.SaveChanges();
            Transaction addedTransaction = null;

            if (TransactionValidation.TransactionIsValid(newTransaction))
            {
              addedTransaction = Controller<TheMobileShopEntities, Transaction>.AddEntity(newTransaction);
            }

            if (addedTransaction == null)
                MessageBox.Show("Error adding transaction");
            else
            {
                foreach (ItemQuantity item in cart)
                {
                    TransactionProduct newItemList = new TransactionProduct()
                    {
                        Transaction = addedTransaction,
                        Inventory = item.Inventory,
                        Quantity = item.quantity,
                        Discount = 0
                    };
                    TransactionProduct addedItemList = Controller<TheMobileShopEntities, TransactionProduct>.AddEntity(newItemList);
                }

                TheMobileShopCheckout checkoutForm = new TheMobileShopCheckout();
                OpenAndHideForm(checkoutForm);
            }


        }

        private void ButtonInventory_Click(object sender, EventArgs e)
        {
            TheMobileShopInventory inventoryForm = new TheMobileShopInventory();
            var showFormDialog = inventoryForm.ShowDialog();
            if (showFormDialog == DialogResult.OK)
            {
                // reload the datagridview
                dataGridViewInventory.DataSource = Controller<TheMobileShopEntities, Inventory>.SetBindingList();
                dataGridViewInventory.Refresh();

            }
            // hide the child form
            inventoryForm.Hide();

        }

        private void InitializeDataGridView<T>(DataGridView gridView, params string[] columnsToHide) where T : class
        {
            // add the Binding List to the datagridview
            gridView.DataSource = Controller<TheMobileShopEntities, T>.SetBindingList();

            // go through the columns that we don't want to display - and set them to not visible
            foreach (string column in columnsToHide)
                gridView.Columns[column].Visible = false;
            gridView.Columns["CategoryId"].HeaderText = "Category";

            // Don't allow users to add/delete rows, and fill out columns to the entire width of the control
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.ReadOnly = true;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private static void InitializeInventoryView(DataGridView dataGridView)
        {

            dataGridView.Columns.Clear();

            DataGridViewTextBoxColumn[] dataGridColumns = new DataGridViewTextBoxColumn[]
          {
                new DataGridViewTextBoxColumn() { Name = "Name"},
                new DataGridViewTextBoxColumn() { Name = "Category" },
                new DataGridViewTextBoxColumn() { Name = "Brand" },
                new DataGridViewTextBoxColumn() { Name = "Quantity" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
          };

            dataGridView.Columns.AddRange(dataGridColumns);

            // unit-of-work context
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                // loop through 
                foreach (Inventory item in context.Inventories)
                {
                    string[] rowAdd = { item.Name, item.Category.CategoryName, item.Brand, item.Quantity.ToString(), item.Price.ToString() };
                    dataGridView.Rows.Add(rowAdd);

                }
            }
            // set all properties
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private static void InitializeCartView(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();

            DataGridViewTextBoxColumn[] dataGridColumns = new DataGridViewTextBoxColumn[]
          {
              new DataGridViewTextBoxColumn() { Name = "ID"},
                new DataGridViewTextBoxColumn() { Name = "Name"},
                new DataGridViewTextBoxColumn() { Name = "Category" },
                new DataGridViewTextBoxColumn() { Name = "Brand" },
                new DataGridViewTextBoxColumn() { Name = "Quantity" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                new DataGridViewTextBoxColumn() { Name = "Discount" },
          };

            dataGridView.Columns.AddRange(dataGridColumns);

            // unit-of-work context

            // set all properties
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = true;
            dataGridView.ReadOnly = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ReloadDataGridView(TheMobileShopEntities context)
        {
            // clear all rows
            dataGridViewInventory.Rows.Clear();
            BindingList<Inventory> test = Controller<TheMobileShopEntities, Inventory>.SetBindingList();



            dataGridViewInventory.DataSource = Controller<TheMobileShopEntities, Inventory>.SetBindingList();
            dataGridViewInventory.Refresh();


            dataGridViewCart.Rows.Clear();
            double subTotal = 0;

            /* foreach (ItemQuantity item in cart)
             {
                 string[] addRow = { item.Inventory.Name, item.Inventory.Category.CategoryName,
                     item.Inventory.Brand, item.quantity.ToString(), item.Inventory.Price.ToString(), "" };
                 dataGridViewCart.Rows.Add(addRow);

                 subTotal += item.Inventory.Price * item.quantity;

             }*/

            for (int x = 0; x < cart.Count; x++)
            {
                string[] addRow = { cart[x].Inventory.ProductId.ToString(), cart[x].Inventory.Name, cart[x].Inventory.Category.CategoryName,
                    cart[x].Inventory.Brand, cart[x].quantity.ToString(), cart[x].Inventory.Price.ToString(), "" };
                dataGridViewCart.Rows.Add(addRow);

                subTotal += cart[x].Inventory.Price * cart[x].quantity;

            }

            tax = subTotal * 0.12;
            total = subTotal + tax;

            labelSubTotalAmount.Text = subTotal.ToString("C");
            labelTaxAmount.Text = tax.ToString("C");
            labelTotal.Text = total.ToString("C");


        }
        /// <summary>
        /// Get employee info from LoginForm
        /// setup admin buttons visability based on role
        /// </summary>
        public void GetEmployeeInfo()
        {
            //get employee from login form
            Employee employee = TheMobileShopLogin.loggedInEmployee;

            labelLoginName.Text = $"{ employee.FirstName} {employee.LastName}";
            if (employee.IsAdmin == 1)
            {
                groupBoxAdmin.Visible = true;
                labelRole.Text = "Administrator";
                buttonAdminDashboard.Visible = true;

            }
            else
            {
                groupBoxAdmin.Visible = false;
                labelRole.Text = "Employee";
                buttonAdminDashboard.Visible = false;
            }

        }
    }
    /// <summary>
    /// Inventory Item quantity class
    /// to keep track of amount of items in cart
    /// </summary>
    public class ItemQuantity
    {
        public Inventory Inventory { get; set; }
        public int quantity { get; set; }
    }
}
