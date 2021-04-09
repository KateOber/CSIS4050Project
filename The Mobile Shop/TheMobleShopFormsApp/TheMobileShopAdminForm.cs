using DataTableAccessLayer;
using EFControllerUtilities;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TheMobileShopCodeFirstFromDB;

namespace TheMobleShopFormsApp
{
    public partial class TheMobileShopAdminForm : Form
    {
        Employee[] employees;
        public TheMobileShopAdminForm()
        {
            InitializeComponent();
            // set up and initialize our controls
            initializeComponents();
        }

        /// <summary>
        /// Our method to initialise app components
        /// </summary>
        private void initializeComponents()
        {
            Text = "The Mobile Shop Admin Dashboard";

            setListeners();
            setUpPickersData();
            loadDataToListBoxes();
        }
        /// <summary>
        /// click listeners for buttons in form
        /// </summary>
        private void setListeners()
        {
            buttonClose.Click += ButtonClose_Click;
            buttonDatabaseBackup.Click += ButtonDatabaseBackup_Click;
            buttonGenerateSalesReport.Click += GenerateSalesReport;
            buttonGenerateInventoryReport.Click += GenerateInventoryReport;
            buttonInventoryToLoad.Click += GenerateInventoryReport;
        }

        /// <summary>
        /// setting the data for date pickers
        /// </summary>
        private void setUpPickersData()
        {
            // setting custom format for better user feel
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = "dd/MM/yyyy";

            // setting date picker max value and date to today
            dateTimePickerTo.Value = DateTime.Today;
            dateTimePickerTo.MaxDate = DateTime.Today;

            // setting date picker max value to yesterday and date to 30days ago
            dateTimePickerFrom.Value = DateTime.Today.AddDays(-30);
            dateTimePickerFrom.MaxDate = DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// loads data to list box for filtering
        /// </summary>
        private void loadDataToListBoxes()
        {
            employees = Controller<TheMobileShopEntities, Employee>.GetEntities().ToArray();
            foreach (Employee employee in employees)
            {
                listBoxEmployees.Items.Add(employee.EmployeeCode + " - " + employee.FirstName + " " + employee.LastName);
            }
            listBoxEmployees.SelectedIndex = 0;
        }

        /// <summary>
        /// Click event for inventory group buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateInventoryReport(object sender, EventArgs e)
        {
            bool showQuant = sender == buttonGenerateInventoryReport;
            // get a new access layer and dataset
            SqlDataTableAccessLayer theMobileShopDB = new SqlDataTableAccessLayer();

            //setup connection string from the app.config
            string connectionString = theMobileShopDB.GetConnectionString("TheMobileShopConnection");

            //opening connection to the Database
            theMobileShopDB.OpenConnection(connectionString);

            //get data from db into datatable
            DataTable table = theMobileShopDB.GetDataTable("Inventory", "Select ProductId, Name, Brand " + (showQuant ? ",Quantity" : "") + " From[Inventory] WHERE Quantity" + (showQuant ? ">0" : "=0"));

            //sets data from datatable to datagridview
            setInventoryIntoDataGridView(table, showQuant);

            //close connection
            theMobileShopDB.CloseConnection();

        }

        /// <summary>
        /// showQunatity is condition used for showing whether quantity empty products or rest of the products.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="showQuantity"></param>
        private void setInventoryIntoDataGridView(DataTable array, bool showQuantity)
        {
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.AllowUserToDeleteRows = false;
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReports.Columns.Clear();

            DataGridViewTextBoxColumn[] dataGridColumns;
            if (showQuantity)
            {
                //columns for showing records when show inventory clicked
                dataGridColumns = new DataGridViewTextBoxColumn[]
              {
                new DataGridViewTextBoxColumn() { Name = "ID"},
                new DataGridViewTextBoxColumn() { Name = "Name" },
                new DataGridViewTextBoxColumn() { Name = "Brand" },
                new DataGridViewTextBoxColumn() { Name = "Quantity" }
              };
            }
            else
            {
                //columns for showing records when show inventory to order clicked
                dataGridColumns = new DataGridViewTextBoxColumn[]
                 {
                new DataGridViewTextBoxColumn() { Name = "ID"},
                new DataGridViewTextBoxColumn() { Name = "Name" },
                new DataGridViewTextBoxColumn() { Name = "Brand" }
                 };
            }

            dataGridViewReports.Columns.AddRange(dataGridColumns);

            foreach (DataRow item in array.Rows)
            {
                dataGridViewReports.Rows.Add(item.ItemArray);
            }
        }

        /// <summary>
        /// Shows data from db into datagridview
        /// </summary>
        /// <param name="array"></param>
        private void setSalesIntoDataGridView(DataTable array)
        {
            dataGridViewReports.AllowUserToAddRows = false;
            dataGridViewReports.AllowUserToDeleteRows = false;
            dataGridViewReports.ReadOnly = true;
            dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReports.Columns.Clear();
            DataGridViewTextBoxColumn[] dataGridColumns;
            dataGridColumns = new DataGridViewTextBoxColumn[]
              {
                    new DataGridViewTextBoxColumn() { Name = "ID"},
                    new DataGridViewTextBoxColumn() { Name = "Date" },
                    new DataGridViewTextBoxColumn() { Name = "Payment Method" },
                    new DataGridViewTextBoxColumn() { Name = "Total Cost" },
                    new DataGridViewTextBoxColumn() { Name = "Tax" },
                    new DataGridViewTextBoxColumn() { Name = "Discount" },
                    new DataGridViewTextBoxColumn() { Name = "Total Price" },
                    new DataGridViewTextBoxColumn() { Name = "Employee" }
              };
            dataGridViewReports.Columns.AddRange(dataGridColumns);

            foreach (DataRow item in array.Rows)
            {
                var arrayTemp = item.ItemArray;
                // for getting employee name from id
                arrayTemp[7] = getEmployeeName((int)item.ItemArray[7]);
                dataGridViewReports.Rows.Add(arrayTemp);
            }
        }

        /// <summary>
        /// For getting employee name from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getEmployeeName(int id)
        {
            foreach (Employee item in employees)
            {
                if (item.EmployeeId == id) return item.FirstName + " " + item.LastName;
            }
            return "";
        }

        /// <summary>
        /// Generate sales report button click where we apply filters and show data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateSalesReport(object sender, EventArgs e)
        {
            SqlDataTableAccessLayer theMobileShopDB = new SqlDataTableAccessLayer();

            //setup connection string from the app.config
            string connectionString = theMobileShopDB.GetConnectionString("TheMobileShopConnection");

            //opening connection to the Database
            theMobileShopDB.OpenConnection(connectionString);

            // filter using employee id and date range
            string query = "From[Transactions] WHERE EmployeeId=" + employees[listBoxEmployees.SelectedIndex].EmployeeId + " AND Date between '" + dateTimePickerFrom.Value.Date.ToString() + "' and'" + dateTimePickerTo.Value.Date.ToString() + "'";
            DataTable table = theMobileShopDB.GetDataTable("Transactions", "Select distinct * " + query);
            // getting revenue/sum of total sales from the db
            var totalPrice = theMobileShopDB.GetTotalFromSales("Select SUM(TotalPrice) as total " + query);
            labelTotalPrice.Text = totalPrice;
            // no of transactions made
            labelTotalCost.Text = table.Rows.Count + "";

            setSalesIntoDataGridView(table);

            //close connection
            theMobileShopDB.CloseConnection();
        }

        /// <summary>
        /// Backup to database is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDatabaseBackup_Click(object sender, EventArgs e)
        {
            //dataset holds all the tables and data
            DataSet theMobileShopDataSet;
            // get a new access layer and dataset
            SqlDataTableAccessLayer theMobileShopDB = new SqlDataTableAccessLayer();

            theMobileShopDataSet = new DataSet()
            {
                //named for the xml backup file
                DataSetName = "TheMobileShopDatabaseBackUp" + DateTime.Now.ToFileTime(),
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
                "Database backup file created at \nThe Mobile Shop\\TheMobleShopFormsApp\\bin\\Debug" :
                "Backup File wasn't created"
                );

            //close connection
            theMobileShopDB.CloseConnection();

        }
        /// <summary>
        /// For closing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
