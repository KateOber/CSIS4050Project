
namespace TheMobleShopFormsApp
{
    partial class TheMobileShopAdminForm
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
            this.buttonGenerateSalesReport = new System.Windows.Forms.Button();
            this.buttonDatabaseBackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelSalesByEmp = new System.Windows.Forms.Label();
            this.listBoxEmployees = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInventoryToLoad = new System.Windows.Forms.Button();
            this.buttonGenerateInventoryReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerateSalesReport
            // 
            this.buttonGenerateSalesReport.Location = new System.Drawing.Point(224, 300);
            this.buttonGenerateSalesReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGenerateSalesReport.Name = "buttonGenerateSalesReport";
            this.buttonGenerateSalesReport.Size = new System.Drawing.Size(226, 41);
            this.buttonGenerateSalesReport.TabIndex = 5;
            this.buttonGenerateSalesReport.Text = "Generate Sales Report";
            this.buttonGenerateSalesReport.UseVisualStyleBackColor = true;
            // 
            // buttonDatabaseBackup
            // 
            this.buttonDatabaseBackup.Location = new System.Drawing.Point(90, 311);
            this.buttonDatabaseBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDatabaseBackup.Name = "buttonDatabaseBackup";
            this.buttonDatabaseBackup.Size = new System.Drawing.Size(266, 47);
            this.buttonDatabaseBackup.TabIndex = 4;
            this.buttonDatabaseBackup.Text = "Database XML export";
            this.buttonDatabaseBackup.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelSalesByEmp);
            this.groupBox2.Controls.Add(this.listBoxEmployees);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerTo);
            this.groupBox2.Controls.Add(this.dateTimePickerFrom);
            this.groupBox2.Controls.Add(this.buttonGenerateSalesReport);
            this.groupBox2.Location = new System.Drawing.Point(466, 47);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(674, 372);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Data";
            // 
            // labelSalesByEmp
            // 
            this.labelSalesByEmp.AutoSize = true;
            this.labelSalesByEmp.Location = new System.Drawing.Point(21, 43);
            this.labelSalesByEmp.Name = "labelSalesByEmp";
            this.labelSalesByEmp.Size = new System.Drawing.Size(198, 25);
            this.labelSalesByEmp.TabIndex = 11;
            this.labelSalesByEmp.Text = "Sales By Employee";
            // 
            // listBoxEmployees
            // 
            this.listBoxEmployees.FormattingEnabled = true;
            this.listBoxEmployees.ItemHeight = 25;
            this.listBoxEmployees.Location = new System.Drawing.Point(26, 73);
            this.listBoxEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxEmployees.Name = "listBoxEmployees";
            this.listBoxEmployees.Size = new System.Drawing.Size(594, 129);
            this.listBoxEmployees.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 216);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 216);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "";
            this.dateTimePickerTo.Location = new System.Drawing.Point(354, 246);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(266, 31);
            this.dateTimePickerTo.TabIndex = 6;
            this.dateTimePickerTo.Value = new System.DateTime(2021, 4, 8, 0, 0, 0, 0);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "";
            this.dateTimePickerFrom.Location = new System.Drawing.Point(26, 246);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(277, 31);
            this.dateTimePickerFrom.TabIndex = 4;
            this.dateTimePickerFrom.Value = new System.DateTime(2021, 4, 8, 0, 0, 0, 0);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(90, 408);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(266, 47);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Back to Main Page";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new System.Drawing.Point(466, 457);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.RowHeadersWidth = 82;
            this.dataGridViewReports.RowTemplate.Height = 33;
            this.dataGridViewReports.Size = new System.Drawing.Size(1108, 467);
            this.dataGridViewReports.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Reports Data";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonInventoryToLoad);
            this.groupBox1.Controls.Add(this.buttonGenerateInventoryReport);
            this.groupBox1.Location = new System.Drawing.Point(1168, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(329, 188);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Data";
            // 
            // buttonInventoryToLoad
            // 
            this.buttonInventoryToLoad.Location = new System.Drawing.Point(21, 113);
            this.buttonInventoryToLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonInventoryToLoad.Name = "buttonInventoryToLoad";
            this.buttonInventoryToLoad.Size = new System.Drawing.Size(300, 41);
            this.buttonInventoryToLoad.TabIndex = 6;
            this.buttonInventoryToLoad.Text = "Inventory To Stock";
            this.buttonInventoryToLoad.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateInventoryReport
            // 
            this.buttonGenerateInventoryReport.Location = new System.Drawing.Point(21, 43);
            this.buttonGenerateInventoryReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGenerateInventoryReport.Name = "buttonGenerateInventoryReport";
            this.buttonGenerateInventoryReport.Size = new System.Drawing.Size(300, 41);
            this.buttonGenerateInventoryReport.TabIndex = 5;
            this.buttonGenerateInventoryReport.Text = "Inventory Report";
            this.buttonGenerateInventoryReport.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(859, 946);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total Price:";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(1016, 946);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(0, 25);
            this.labelTotalPrice.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1242, 946);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total Sales:";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(1369, 946);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(0, 25);
            this.labelTotalCost.TabIndex = 17;
            // 
            // TheMobileShopAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 1002);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDatabaseBackup);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TheMobileShopAdminForm";
            this.Text = "AdminForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateSalesReport;
        private System.Windows.Forms.Button buttonDatabaseBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ListBox listBoxEmployees;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelSalesByEmp;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGenerateInventoryReport;
        private System.Windows.Forms.Button buttonInventoryToLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTotalCost;
    }
}