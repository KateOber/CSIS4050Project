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
    public partial class TheMobileShopLogin : Form
    {
        public TheMobileShopLogin()
        {
            InitializeComponent();

            
            buttonLogin.Click += ButtonLogin_Click;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            TheMobileShopMainForm mainForm = new TheMobileShopMainForm();
            mainForm.Show();
            //this.Close();
        }
    }
}
