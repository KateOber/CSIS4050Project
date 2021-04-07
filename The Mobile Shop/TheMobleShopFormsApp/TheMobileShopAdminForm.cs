using DataTableAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMobleShopFormsApp
{
    public partial class TheMobileShopAdminForm : Form
    {
        public TheMobileShopAdminForm()
        {
            InitializeComponent();

            this.Text = "The Mobile Shop Admin Dashboard";
            buttonClose.Click += ButtonClose_Click;
            buttonDatabaseBackup.Click += ButtonDatabaseBackup_Click;


        }

        private void ButtonDatabaseBackup_Click(object sender, EventArgs e)
        {
            //dataset holds all the tables and data
            DataSet theMobileShopDataSet;
            // get a new access layer and dataset
            SqlDataTableAccessLayer theMobileShopDB = new SqlDataTableAccessLayer();

            theMobileShopDataSet = new DataSet()
            {
                //named for the xml backup file
                DataSetName = "TheMobileShopDatabase",
            };

            //setup connection string from the app.config
            string connectionString = theMobileShopDB.GetConnectionString("TheMobileShopConnection");

            //opening connection to the Database
            theMobileShopDB.OpenConnection(connectionString);

            //get all the tables
            DataTable[] tables =
            {
                theMobileShopDB.GetDataTable("Employees"),
                theMobileShopDB.GetDataTable("Categories"),
                theMobileShopDB.GetDataTable("Inventory"),
                theMobileShopDB.GetDataTable("Transactions"),
                theMobileShopDB.GetDataTable("TransactionProducts")

            };

            //add tables to DataSet
            theMobileShopDataSet.Tables.AddRange(tables);
            //backup to xml
            theMobileShopDB.BackupDataSetToXML(theMobileShopDataSet);
            //check if file was created
            string backupFile = theMobileShopDataSet.DataSetName + ".xml";
                MessageBox.Show(File.Exists(backupFile) ?
                    "Database backup file created at \nThe Mobile Shop\\TheMobleShopFormsApp\\bin\\Debug":
                    "Backup File wasn't created"
                    );

            //close connection
            theMobileShopDB.CloseConnection();

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
