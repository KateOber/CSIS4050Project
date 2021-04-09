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

    public partial class TheMobileShopMainForm : Form
    {
        List<ItemQuantity> cart = new List<ItemQuantity>();

        double tax = 0;
        double total = 0;

        public TheMobileShopMainForm()
        {
            InitializeComponent();

            this.Text = "The Mobile Shop";

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
            dataGridViewCart.CellEndEdit += DataGridViewCart_CellEndEdit;


        }

        private void DataGridViewCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DiscountEdit(dataGridViewCart);
        }
        /// <summary>
        /// Removes Items from cart and adds their quantity back to inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count >= 1)
            {
                //get all the selected rows
                foreach (DataGridViewRow row in dataGridViewCart.SelectedRows)
                {
                    //get product ID and quantity from selected row
                    int productId = Int32.Parse(row.Cells[0].Value.ToString());
                    int productQuantity = Int32.Parse(row.Cells[4].Value.ToString());

                    using (TheMobileShopEntities context = new TheMobileShopEntities())
                    {
                        //find the item in the Database (context)
                        Inventory itemFromContext = context.Inventories.Find(productId);

                        for (int x = 0; x < cart.Count; x++)
                        {
                            //find the selected item in cart, decrease quantity by 1 or remove
                            if (itemFromContext.ProductId == cart[x].Inventory.ProductId)
                            {
                                //item will be removed from cart if there was only 1
                                if (cart[x].quantity > 1)
                                    cart[x].quantity--;
                                else
                                    cart.RemoveAt(x);
                            }
                        }
                        //increase item quantity in inventory
                        itemFromContext.Quantity++;
                        context.SaveChanges();

                        //reload Cart and Inventory DataGridView
                        ReloadDataGridView();
                    }

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
            ReloadDataGridView();
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
                "AmericanExpress",
                "Debit"
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
                                cart.Add(new ItemQuantity { Inventory = itemFromContext, quantity = 1, discount = 0 });
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
                                    cart.Add(new ItemQuantity { Inventory = itemFromContext, quantity = 1, discount = 0 });
                                }
                            }
                            //Subtract item quantity from inventory and save context
                            itemFromContext.Quantity--;
                            context.SaveChanges();
                        }
                    }
                    //reload Cart and Inventory DataGridView
                    ReloadDataGridView();
                }


            }

        }
        /// <summary>
        /// Search for specific item by applying filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string brand = textBoxBrand.Text.Trim();
            string name = textBoxName.Text.Trim().ToLower();
            bool boolPriceMin = Double.TryParse(textBoxPriceMin.Text, out double priceMin);
            bool boolPriceMax = Double.TryParse(textBoxPriceMax.Text, out double priceMax);
            int catId = 0;

            if (listBoxCategory.SelectedIndex != -1)
            {
                string cat = listBoxCategory.SelectedItem.ToString();
                TheMobileShopEntities context = new TheMobileShopEntities();
                var categ = context.Categories.Where(c => c.CategoryName == cat).Single();
                catId = categ.CategoryId;
            }


            BindingList<Inventory> inventoryList = Controller<TheMobileShopEntities, Inventory>.SetBindingList();

            for (int x = inventoryList.Count - 1; x >= 0; x--)
            {
                string t = inventoryList[x].CategoryId.ToString();
                if (name != "")
                {
                    if (!(inventoryList[x].Name.ToLower().Contains(name)))
                        inventoryList.Remove(inventoryList[x]);
                }
                if (brand != "")
                {
                    if (!(inventoryList[x].Brand.ToLower().Contains(brand)))
                        inventoryList.Remove(inventoryList[x]);
                }
                if (catId != 0)
                {
                    if (inventoryList[x].CategoryId != catId)
                        inventoryList.Remove(inventoryList[x]);
                }
                if (priceMin != 0)
                {
                    if (inventoryList[x].Price < priceMin)
                        inventoryList.Remove(inventoryList[x]);
                }
                if (priceMax != 0)
                {
                    if (inventoryList[x].Price > priceMax)
                        inventoryList.Remove(inventoryList[x]);
                }
            }

            dataGridViewInventory.DataSource = inventoryList;
            dataGridViewInventory.Refresh();

        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {

            double totalCost = 0;
            double totalDiscount = 0;

            if (cart.Count != 0)
            {
                if(listBoxPaymentMethod.SelectedIndex != -1) 
                { 
                string paymentMethod = listBoxPaymentMethod.SelectedItem.ToString();
               
                foreach (ItemQuantity item in cart)
                {
                    totalCost += item.Inventory.Cost * item.quantity;
                    totalDiscount += item.discount;
                }

                Transaction newTransaction = new Transaction()
                {
                    TotalPrice = total,
                    TaxAmount = tax,
                    TotalDiscount = totalDiscount,
                    EmployeeId = TheMobileShopLogin.loggedInEmployee.EmployeeId,
                    Date = DateTime.Now,
                    PaymentMethod = paymentMethod,
                    TotalCost = totalCost,
                };

                Debug.WriteLine("inventoryList " + newTransaction.TotalPrice + newTransaction.PaymentMethod + newTransaction.TaxAmount);

                Transaction addedTransaction = null;
                List<TransactionProduct> addedItemList = new List<TransactionProduct>();

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
                            Discount = item.discount
                        };

                        addedItemList.Add(Controller<TheMobileShopEntities, TransactionProduct>.AddEntity(newItemList));
                    }

                        if (addedItemList.Count != 0)
                        {
                            TheMobileShopCheckout checkoutForm = new TheMobileShopCheckout(addedItemList);
                            OpenAndHideForm(checkoutForm);
                            cart.Clear();
                            listBoxPaymentMethod.SelectedIndex = -1;
                            ReloadDataGridView();
                        }
                }
                }

                else
                    MessageBox.Show("Select Payment Method");
            }
            else
                MessageBox.Show("No Items to Checkout");

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
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


            // set all properties
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = true;
            dataGridView.ReadOnly = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void DiscountEdit(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                double idinventoryList2 = Double.Parse(row.Cells[6].Value.ToString());
                int idinventoryList = Int32.Parse(row.Cells[0].Value.ToString());
                for (int x = 0; x < cart.Count; x++)
                {
                    if (cart[x].Inventory.ProductId == idinventoryList)
                    {
                        cart[x].discount = idinventoryList2;

                    }
                }
            }
            ReloadDataGridView();
        }

        private void ReloadDataGridView()
        {
            // clear all rows
            dataGridViewInventory.Rows.Clear();
            BindingList<Inventory> inventoryList = Controller<TheMobileShopEntities, Inventory>.SetBindingList();



            dataGridViewInventory.DataSource = Controller<TheMobileShopEntities, Inventory>.SetBindingList();
            dataGridViewInventory.Refresh();

            dataGridViewCart.CellEndEdit -= DataGridViewCart_CellEndEdit;

            dataGridViewCart.Rows.Clear();

            double subTotal = 0;
            double discount = 0;

            foreach (ItemQuantity item in cart)
            {
                string[] addRow = { item.Inventory.ProductId.ToString(), item.Inventory.Name, item.Inventory.Category.CategoryName,
                     item.Inventory.Brand, item.quantity.ToString(), item.Inventory.Price.ToString(), item.discount.ToString()};
                dataGridViewCart.Rows.Add(addRow);

                subTotal += item.Inventory.Price * item.quantity;
                discount += item.discount;
            }

            subTotal -= discount;
            tax = subTotal * 0.12;
            total = subTotal + tax;

            labelSubTotalAmount.Text = subTotal.ToString("C");
            labelTaxAmount.Text = tax.ToString("C");
            labelTotal.Text = total.ToString("C");
            labelDiscountAmount.Text = "- $ " + discount.ToString("n2");
            dataGridViewCart.CellEndEdit += DataGridViewCart_CellEndEdit;

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
    /// and their discount
    /// </summary>
    public class ItemQuantity
    {
        public Inventory Inventory { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
    }
}
