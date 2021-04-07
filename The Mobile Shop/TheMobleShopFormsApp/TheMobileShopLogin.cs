﻿using System;
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
    public partial class TheMobileShopLogin : Form
    {
       
        public TheMobileShopLogin()
        {
            InitializeComponent();
            this.Load += TheMobileShopLogin_Load;

            

            this.Text = "The Mobile Shop Login";

            buttonLogin.Click += ButtonLogin_Click;
            buttonAdmin.Click += (s,e) => GetEmployeeCode("admin");
            buttonRegular.Click += (s, e) => GetEmployeeCode("reg");
        }

        private void TheMobileShopLogin_Load(object sender, EventArgs e)
        {
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                context.SeedDatabase();
            }

        }
        public void GetEmployeeCode(string role)
        {
            if (role == "admin")
                textBoxEmployeeCode.Text = "ADM-001";
            else
                textBoxEmployeeCode.Text = "EMP-001";
        }
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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            String employeeCode = textBoxEmployeeCode.Text.Trim().ToUpper();
            if (employeeCode == "")
            {
                textBoxEmployeeCode.BackColor = Color.Red;
                labelLoginError.Text = "Please Enter Employee Code";
            }
            else
            {
                textBoxEmployeeCode.BackColor = Color.White;
                labelLoginError.Text = "";

                if (CheckEmployeeCode(employeeCode))
                {
                    TheMobileShopMainForm mainForm = new TheMobileShopMainForm();
                    OpenAndHideForm(mainForm);
               }
                else
                   labelLoginError.Text = "Incorrect Employee Code";
            }

            //possible disable X
        } 
        public static Employee loggedInEmployee;
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
