using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataTableAccessLayer
{
	/// <summary>
	/// Set of methods update a sql database when a DataTable is changed.
	/// 
	/// DataTable event handlers should use these methods to update the database.
	/// 
	/// This is really a "connected" version of the Disconnected ADO.NET layer, as the
	/// sql connection is always alive. The connection could be closed after each transaction
	/// to make it disconnected, but the fill/update logic is basically the same.
	/// 
	/// TODO: generally a base Exception is thrown when there is an error. This should be a specific
	/// exception
	///
	/// </summary>
	public class SqlDataTableAccessLayer
	{
		// This field will be used by all methods, holds the open connection
		protected SqlConnection sqlConnection = null;

		/// <summary>
		/// Open a connection to the sql database
		/// </summary>
		/// <param name="connectionString">Database connection string</param>
		public void OpenConnection(string connectionString)
		{
			sqlConnection = new SqlConnection { ConnectionString = connectionString };
			sqlConnection.Open();
		}

		/// <summary>
		/// Close the sql database connection
		/// </summary>
		public void CloseConnection()
		{
			sqlConnection.Close();
		}

		/// <summary>
		/// Gets the connection string from the app.config file
		/// 
		/// Note: this needs System.Configuration dll reference added
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetConnectionString(string key)
		{
			if (key == null)
			{
				return null;
			}

			return ConfigurationManager.ConnectionStrings[key].ConnectionString;
		}

		/// <summary>
		/// Simple method to create and fill a DataTable object
		/// from any sql table.
		/// 
		/// Primary key columns are set.
		/// </summary>
		/// <param name="tableName">Name of the sql table</param>
		/// <returns>DataTable containing the sql data or null if table does not exist</returns>
		public DataTable GetDataTable(string tableName)
		{
			if (tableName == null)
				return null;

			DataTable dataTable = new DataTable
			{
				TableName = tableName,
			};

			// load the data from the database into the DataTable object

			LoadDataTable(dataTable);

			// get the primary keys from the database for the table, and load into the object

			SetPrimaryKey(dataTable);
			dataTable.AcceptChanges();

			return dataTable;
		}

		/// <summary>
		/// Set the primary keys in a data table.
		/// 
		/// Need to get the table schema by executing a select command on the table
		/// and return key information.
		/// 
		/// This will also work for composite keys
		/// 
		/// Should only need to do this once when getting the table from the db.
		/// </summary>
		/// <param name="table"></param>
		private void SetPrimaryKey(DataTable table)
		{
			if (table == null)
				return;

			// select command 

			var sqlCommand =
				new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("SetPrimaryKey: " + sqlCommand.CommandText);

			// get the table schema, and make sure we obtain the keys as well

			using (SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.KeyInfo))
			{
				// the schema is returned as a data table

				DataTable schema = dataReader.GetSchemaTable();

				// keep a list of all of the columns that are primary keys

				List<DataColumn> keyColumnList = new List<DataColumn>();

				// each row in the schema table contains metadata about columns in table
				// check to see which columns are keys, and add them to the list

				foreach (DataRow row in schema.Rows)
				{
					// is it a primary key?

					if ((bool)row["IsKey"] == true)
					{
						// get the column index of the primary key

						int columnOrdinal = (int)row["ColumnOrdinal"];

						// make sure it is one of the table columns, and if so add it to the key list

						if (columnOrdinal < table.Columns.Count)
						{
							keyColumnList.Add(table.Columns[columnOrdinal]);
							Debug.WriteLine("  Primary Key found: " + table.TableName + " " +
								row["ColumnName"] + " Column " + columnOrdinal);
						}
					}
				}

				// the PrimaryKey property is an array, so convert it and we are done

				table.PrimaryKey = keyColumnList.ToArray();
			}
		}

		/// <summary>
		/// Load records from a database table into an existing DataTable.
		/// 
		/// The DataTable must exist and have a TableName property set
		/// to a table that exists in the SQL database
		/// 
		/// The DataTable is cleared before the records are added, so
		/// any existing rows in the DataTable are removed.
		/// </summary>
		/// <param name="table">DataTable to be loaded</param>
		public void LoadDataTable(DataTable table)
		{
			table.Clear();

			var sqlCommand =
				new SqlCommand("Select * From [" + table.TableName + "]", sqlConnection);

			Debug.WriteLine("LoadDataTable: " + sqlCommand.CommandText);

			using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
			{
				// Fill the DataTable with data from the reader. This
				// set up the schema in the DataTable as well.

				table.Load(dataReader);
			}

			table.AcceptChanges();
		}


		
		public void BackupDataSetToXML(DataSet dataSet)
		{
			if (dataSet == null)
			{
				Debug.WriteLine("BackupDataSetToXML: Error - null dataset");
				return;
			}

			// writes the DataSet to an xml file including the schema

			Debug.WriteLine("BackupDataSetToXML: backing up to " + dataSet.DataSetName);

			dataSet.WriteXml(dataSet.DataSetName + ".xml", XmlWriteMode.WriteSchema);
		}

	}
}
