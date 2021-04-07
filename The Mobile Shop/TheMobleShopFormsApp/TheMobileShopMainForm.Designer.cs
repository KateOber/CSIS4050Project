
namespace TheMobleShopFormsApp
{
    partial class TheMobileShopMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.buttonPurchaseHistory = new System.Windows.Forms.Button();
            this.labelPaymentMethod = new System.Windows.Forms.Label();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.labelSubTotal = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelTotalTxt = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTaxAmount = new System.Windows.Forms.Label();
            this.labelSubTotalAmount = new System.Windows.Forms.Label();
            this.labelDiscountAmount = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.buttonAdminDashboard = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxPaymentMethod = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.textBoxPriceMax = new System.Windows.Forms.TextBox();
            this.textBoxPriceMin = new System.Windows.Forms.TextBox();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCat = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.groupBoxPrice = new System.Windows.Forms.GroupBox();
            this.labelfrom = new System.Windows.Forms.Label();
            this.labelLoginName = new System.Windows.Forms.Label();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.labelCart = new System.Windows.Forms.Label();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.groupBoxAdmin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(44, 12);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RowHeadersWidth = 51;
            this.dataGridViewInventory.RowTemplate.Height = 24;
            this.dataGridViewInventory.Size = new System.Drawing.Size(481, 441);
            this.dataGridViewInventory.TabIndex = 0;
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(970, 29);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(82, 30);
            this.buttonInventory.TabIndex = 1;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            // 
            // buttonPurchaseHistory
            // 
            this.buttonPurchaseHistory.Location = new System.Drawing.Point(1080, 29);
            this.buttonPurchaseHistory.Name = "buttonPurchaseHistory";
            this.buttonPurchaseHistory.Size = new System.Drawing.Size(170, 30);
            this.buttonPurchaseHistory.TabIndex = 2;
            this.buttonPurchaseHistory.Text = "Purchase History";
            this.buttonPurchaseHistory.UseVisualStyleBackColor = true;
            // 
            // labelPaymentMethod
            // 
            this.labelPaymentMethod.AutoSize = true;
            this.labelPaymentMethod.Location = new System.Drawing.Point(876, 507);
            this.labelPaymentMethod.Name = "labelPaymentMethod";
            this.labelPaymentMethod.Size = new System.Drawing.Size(114, 17);
            this.labelPaymentMethod.TabIndex = 4;
            this.labelPaymentMethod.Text = "Payment Method";
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.Location = new System.Drawing.Point(1008, 696);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(82, 31);
            this.buttonCheckout.TabIndex = 7;
            this.buttonCheckout.Text = "Checkout";
            this.buttonCheckout.UseVisualStyleBackColor = true;
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(14, 134);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(69, 17);
            this.labelSubTotal.TabIndex = 8;
            this.labelSubTotal.Text = "Sub Total";
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(14, 151);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(31, 17);
            this.labelTax.TabIndex = 9;
            this.labelTax.Text = "Tax";
            // 
            // labelTotalTxt
            // 
            this.labelTotalTxt.AutoSize = true;
            this.labelTotalTxt.Location = new System.Drawing.Point(14, 201);
            this.labelTotalTxt.Name = "labelTotalTxt";
            this.labelTotalTxt.Size = new System.Drawing.Size(40, 17);
            this.labelTotalTxt.TabIndex = 10;
            this.labelTotalTxt.Text = "Total";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(264, 201);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(48, 17);
            this.labelTotal.TabIndex = 13;
            this.labelTotal.Text = "$ 0.00";
            // 
            // labelTaxAmount
            // 
            this.labelTaxAmount.AutoSize = true;
            this.labelTaxAmount.Location = new System.Drawing.Point(264, 151);
            this.labelTaxAmount.Name = "labelTaxAmount";
            this.labelTaxAmount.Size = new System.Drawing.Size(48, 17);
            this.labelTaxAmount.TabIndex = 12;
            this.labelTaxAmount.Text = "$ 0.00";
            // 
            // labelSubTotalAmount
            // 
            this.labelSubTotalAmount.AutoSize = true;
            this.labelSubTotalAmount.Location = new System.Drawing.Point(264, 134);
            this.labelSubTotalAmount.Name = "labelSubTotalAmount";
            this.labelSubTotalAmount.Size = new System.Drawing.Size(48, 17);
            this.labelSubTotalAmount.TabIndex = 11;
            this.labelSubTotalAmount.Text = "$ 0.00";
            // 
            // labelDiscountAmount
            // 
            this.labelDiscountAmount.AutoSize = true;
            this.labelDiscountAmount.Location = new System.Drawing.Point(255, 168);
            this.labelDiscountAmount.Name = "labelDiscountAmount";
            this.labelDiscountAmount.Size = new System.Drawing.Size(57, 17);
            this.labelDiscountAmount.TabIndex = 15;
            this.labelDiscountAmount.Text = "- $ 0.00";
            // 
            // labelDiscount
            // 
            this.labelDiscount.AutoSize = true;
            this.labelDiscount.Location = new System.Drawing.Point(14, 168);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(63, 17);
            this.labelDiscount.TabIndex = 14;
            this.labelDiscount.Text = "Discount";
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Controls.Add(this.buttonAdminDashboard);
            this.groupBoxAdmin.Location = new System.Drawing.Point(970, 199);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(234, 86);
            this.groupBoxAdmin.TabIndex = 7;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Admin";
            // 
            // buttonAdminDashboard
            // 
            this.buttonAdminDashboard.Location = new System.Drawing.Point(18, 34);
            this.buttonAdminDashboard.Name = "buttonAdminDashboard";
            this.buttonAdminDashboard.Size = new System.Drawing.Size(177, 30);
            this.buttonAdminDashboard.TabIndex = 2;
            this.buttonAdminDashboard.Text = "Admin Dashboard";
            this.buttonAdminDashboard.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxPaymentMethod);
            this.groupBox3.Controls.Add(this.labelSubTotalAmount);
            this.groupBox3.Controls.Add(this.labelSubTotal);
            this.groupBox3.Controls.Add(this.labelDiscountAmount);
            this.groupBox3.Controls.Add(this.labelTax);
            this.groupBox3.Controls.Add(this.labelDiscount);
            this.groupBox3.Controls.Add(this.labelTotalTxt);
            this.groupBox3.Controls.Add(this.labelTotal);
            this.groupBox3.Controls.Add(this.labelTaxAmount);
            this.groupBox3.Location = new System.Drawing.Point(863, 481);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 253);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "POS";
            // 
            // listBoxPaymentMethod
            // 
            this.listBoxPaymentMethod.FormattingEnabled = true;
            this.listBoxPaymentMethod.ItemHeight = 16;
            this.listBoxPaymentMethod.Location = new System.Drawing.Point(16, 51);
            this.listBoxPaymentMethod.Name = "listBoxPaymentMethod";
            this.listBoxPaymentMethod.Size = new System.Drawing.Size(186, 52);
            this.listBoxPaymentMethod.TabIndex = 20;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 51);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(324, 22);
            this.textBoxName.TabIndex = 16;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.buttonReset);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.listBoxCategory);
            this.groupBoxSearch.Controls.Add(this.textBoxPriceMax);
            this.groupBoxSearch.Controls.Add(this.textBoxPriceMin);
            this.groupBoxSearch.Controls.Add(this.textBoxBrand);
            this.groupBoxSearch.Controls.Add(this.textBoxName);
            this.groupBoxSearch.Controls.Add(this.labelProductName);
            this.groupBoxSearch.Controls.Add(this.labelCat);
            this.groupBoxSearch.Controls.Add(this.labelTo);
            this.groupBoxSearch.Controls.Add(this.labelBrand);
            this.groupBoxSearch.Controls.Add(this.groupBoxPrice);
            this.groupBoxSearch.Location = new System.Drawing.Point(546, 12);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(391, 441);
            this.groupBoxSearch.TabIndex = 17;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(9, 399);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(84, 36);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 16;
            this.listBoxCategory.Location = new System.Drawing.Point(9, 273);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(120, 84);
            this.listBoxCategory.TabIndex = 17;
            // 
            // textBoxPriceMax
            // 
            this.textBoxPriceMax.Location = new System.Drawing.Point(202, 138);
            this.textBoxPriceMax.Name = "textBoxPriceMax";
            this.textBoxPriceMax.Size = new System.Drawing.Size(157, 22);
            this.textBoxPriceMax.TabIndex = 16;
            // 
            // textBoxPriceMin
            // 
            this.textBoxPriceMin.Location = new System.Drawing.Point(6, 138);
            this.textBoxPriceMin.Name = "textBoxPriceMin";
            this.textBoxPriceMin.Size = new System.Drawing.Size(157, 22);
            this.textBoxPriceMin.TabIndex = 16;
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(6, 207);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(157, 22);
            this.textBoxBrand.TabIndex = 16;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(6, 31);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(98, 17);
            this.labelProductName.TabIndex = 8;
            this.labelProductName.Text = "Product Name";
            // 
            // labelCat
            // 
            this.labelCat.AutoSize = true;
            this.labelCat.Location = new System.Drawing.Point(6, 253);
            this.labelCat.Name = "labelCat";
            this.labelCat.Size = new System.Drawing.Size(65, 17);
            this.labelCat.TabIndex = 8;
            this.labelCat.Text = "Category";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(199, 118);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(25, 17);
            this.labelTo.TabIndex = 8;
            this.labelTo.Text = "To";
            // 
            // labelBrand
            // 
            this.labelBrand.AutoSize = true;
            this.labelBrand.Location = new System.Drawing.Point(6, 187);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(46, 17);
            this.labelBrand.TabIndex = 8;
            this.labelBrand.Text = "Brand";
            // 
            // groupBoxPrice
            // 
            this.groupBoxPrice.Controls.Add(this.labelfrom);
            this.groupBoxPrice.Location = new System.Drawing.Point(0, 89);
            this.groupBoxPrice.Name = "groupBoxPrice";
            this.groupBoxPrice.Size = new System.Drawing.Size(385, 95);
            this.groupBoxPrice.TabIndex = 19;
            this.groupBoxPrice.TabStop = false;
            this.groupBoxPrice.Text = "Price";
            // 
            // labelfrom
            // 
            this.labelfrom.AutoSize = true;
            this.labelfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfrom.Location = new System.Drawing.Point(6, 29);
            this.labelfrom.Name = "labelfrom";
            this.labelfrom.Size = new System.Drawing.Size(40, 17);
            this.labelfrom.TabIndex = 9;
            this.labelfrom.Text = "From";
            // 
            // labelLoginName
            // 
            this.labelLoginName.AutoSize = true;
            this.labelLoginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginName.Location = new System.Drawing.Point(15, 30);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(45, 17);
            this.labelLoginName.TabIndex = 8;
            this.labelLoginName.Text = "Name";
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(153, 470);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(104, 36);
            this.buttonRemoveItem.TabIndex = 18;
            this.buttonRemoveItem.Text = "Remove Item";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(44, 558);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 24;
            this.dataGridViewCart.Size = new System.Drawing.Size(741, 191);
            this.dataGridViewCart.TabIndex = 18;
            // 
            // labelCart
            // 
            this.labelCart.AutoSize = true;
            this.labelCart.Location = new System.Drawing.Point(41, 532);
            this.labelCart.Name = "labelCart";
            this.labelCart.Size = new System.Drawing.Size(34, 17);
            this.labelCart.TabIndex = 8;
            this.labelCart.Text = "Cart";
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(44, 470);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(84, 36);
            this.buttonAddItem.TabIndex = 18;
            this.buttonAddItem.Text = "Add Item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRole);
            this.groupBox1.Controls.Add(this.labelLoginName);
            this.groupBox1.Controls.Add(this.buttonLogout);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(970, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 104);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "You\'re logged in as";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRole.Location = new System.Drawing.Point(15, 61);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(37, 17);
            this.labelRole.TabIndex = 9;
            this.labelRole.Text = "Role";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(178, 61);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(82, 30);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(113, 399);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(84, 36);
            this.buttonReset.TabIndex = 18;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // TheMobileShopMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 770);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.groupBoxAdmin);
            this.Controls.Add(this.labelCart);
            this.Controls.Add(this.buttonCheckout);
            this.Controls.Add(this.labelPaymentMethod);
            this.Controls.Add(this.buttonPurchaseHistory);
            this.Controls.Add(this.buttonInventory);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxSearch);
            this.Name = "TheMobileShopMainForm";
            this.Text = "TheMobileShopMainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxPrice.ResumeLayout(false);
            this.groupBoxPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Button buttonPurchaseHistory;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.Button buttonCheckout;
        private System.Windows.Forms.Label labelSubTotal;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelTotalTxt;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTaxAmount;
        private System.Windows.Forms.Label labelSubTotalAmount;
        private System.Windows.Forms.Label labelDiscountAmount;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.Button buttonAdminDashboard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxPriceMax;
        private System.Windows.Forms.TextBox textBoxPriceMin;
        private System.Windows.Forms.Label labelCat;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelLoginName;
        private System.Windows.Forms.GroupBox groupBoxPrice;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Label labelCart;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ListBox listBoxPaymentMethod;
        private System.Windows.Forms.Label labelfrom;
        private System.Windows.Forms.Button buttonReset;
    }
}