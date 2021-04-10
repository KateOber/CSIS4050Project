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

namespace TheMobleShopFormsApp
{
    /// <summary>
    /// This class for the regular employee/admin to login to the "The Mobile Shop" application based on the employee code
    /// </summary>
    public partial class TheMobileShopLogin : Form
    {
       
        public TheMobileShopLogin()
        {
            InitializeComponent();

            this.Text = "The Mobile Shop Login";

            //setup button event handlers 
            buttonLogin.Click += ButtonLogin_Click;
            buttonAdmin.Click += (s,e) => GetEmployeeCode("admin");
            buttonRegular.Click += (s, e) => GetEmployeeCode("reg");
            buttonSeedDatabase.Click += ButtonSeedDatabase_Click;
        }

        /// <summary>
        /// the seedDatabase button will load the data into the database and then the login button is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSeedDatabase_Click(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;

            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                context.SeedDatabase();
            }

            buttonLogin.Enabled = true;
        }

        /// <summary>
        /// Sets up employee code with admin or regular privilege 
        /// </summary>
        /// <param name="role"></param>
        public void GetEmployeeCode(string role)
        {
            if (role == "admin")
                textBoxEmployeeCode.Text = "ADM-001";//read only string to hold the admin employee code
            else
                textBoxEmployeeCode.Text = "EMP-001";//read only string to hold the regular employee code
        }
        
        /// <summary>
        ///  This method is called when the Login button is clicked, it hides this form 
        /// </summary>
        public void OpenAndHideForm(Form form)
        {   
            this.Hide();
            var result = form.ShowDialog();  
            if (result == DialogResult.OK)
            {
                form.Hide();
                this.Show();
                textBoxEmployeeCode.ResetText();
            }

        }

        /// <summary>
        /// checks for the employee code textbox if not entered or not valid
        /// error message will be generated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //get the epmloyee code
            string employeeCode = textBoxEmployeeCode.Text.Trim().ToUpper();
            //check if empty
            if (employeeCode == "")
            {
                textBoxEmployeeCode.BackColor = Color.Red;
                labelLoginError.Text = "Please Enter Employee Code";
            }
            //check if valid
            else
            {
                textBoxEmployeeCode.BackColor = Color.White;
                labelLoginError.Text = "";
                //open main form if valid
                if (CheckEmployeeCode(employeeCode))
                {
                    TheMobileShopMainForm mainForm = new TheMobileShopMainForm();
                    OpenAndHideForm(mainForm);
                }
                else labelLoginError.Text = "Incorrect Employee Code";
            }
        } 
        
        public static Employee loggedInEmployee;

        /// <summary>
        /// Check entered employee's code in the Database
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public static bool CheckEmployeeCode(String employeeCode)
        {
            TheMobileShopEntities context = new TheMobileShopEntities();
            Employee employee = context.Employees
                .Where(e => e.EmployeeCode == employeeCode)
                .SingleOrDefault();

            if (employee != null)
            { 
                loggedInEmployee = employee;
                return true;
            }
            else
                return false;
        }

    }
}
