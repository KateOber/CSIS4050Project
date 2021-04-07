
namespace TheMobleShopFormsApp
{
    partial class TheMobileShopPurchaseHistory
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
            this.dataGridViewPurchases = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchases
            // 
            this.dataGridViewPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchases.Location = new System.Drawing.Point(34, 35);
            this.dataGridViewPurchases.Name = "dataGridViewPurchases";
            this.dataGridViewPurchases.RowHeadersWidth = 51;
            this.dataGridViewPurchases.RowTemplate.Height = 24;
            this.dataGridViewPurchases.Size = new System.Drawing.Size(1281, 437);
            this.dataGridViewPurchases.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(647, 490);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // TheMobileShopPurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 525);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewPurchases);
            this.Name = "TheMobileShopPurchaseHistory";
            this.Text = "TheMobileShopPurchaseHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPurchases;
        private System.Windows.Forms.Button buttonClose;
    }
}