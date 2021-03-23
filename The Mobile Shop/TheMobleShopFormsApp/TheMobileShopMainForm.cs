using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMobleShopFormsApp
{
    public partial class TheMobileShopMainForm : Form
    {
        public TheMobileShopMainForm()
        {
            InitializeComponent();

            buttonInventory.Click += ButtonInventory_Click;
            buttonCheckout.Click += ButtonCheckout_Click;
        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
             Checkout checkoutForm = new Checkout();
            checkoutForm.Show();
        }

        private void ButtonInventory_Click(object sender, EventArgs e)
        {   
            TheMobileShopInventory inventoryForm = new TheMobileShopInventory();
            inventoryForm.Show();
           
        }
    }
}
