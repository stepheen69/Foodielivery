using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order
{
    public partial class Admin : Form
    {
        private string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

        public Admin()
        {
            InitializeComponent();
            LoadLoginRecords();
        }

        private void LoadLoginRecords()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT Id, Username, UserType,  LoginTime FROM AdminView";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Debug output to check the dataTable
                        Console.WriteLine("DataTable Rows Count: " + dataTable.Rows.Count);

                        // Debug output to check the first few rows in the DataTable
                        foreach (DataRow row in dataTable.Rows.Cast<DataRow>().Take(5))
                        {
                            Console.WriteLine($"Id: {row["Id"]}, Username: {row["Username"]},UserType: {row["UserType"]}, LoginTime: {row["LoginTime"]}");
                        }

                        // Set the DataTable as the DataSource directly
                        dataGridViewLoginRecords.DataSource = dataTable;

                        // Auto-resize columns and rows to fit content
                        dataGridViewLoginRecords.AutoResizeColumns();
                        dataGridViewLoginRecords.AutoResizeRows();

                        // Set column header size mode to AutoSize
                        dataGridViewLoginRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        // Set row header size mode to AutoSize
                        dataGridViewLoginRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        // Set row header width mode to AutoSizeToAllHeaders
                        dataGridViewLoginRecords.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }





        private void dataGridViewLoginRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
