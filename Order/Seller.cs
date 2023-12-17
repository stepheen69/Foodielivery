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
    public partial class Seller : Form
    {
        private Login loginFormInstance = new Login();
        public Seller()
        {
            InitializeComponent();
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            // Fetch and display data in DataGridView
            FetchAndDisplayData();
            FetchAndDisplayOrderData();
            guna2HtmlLabel4.Text = "Howdy,"+loginFormInstance.GetLoggedInUsername()+"!";
            //guna2Panel1.Controls.Add(guna2HtmlLabel2);
        }

        private void FetchAndDisplayData()
        {
            try
            {
                // Create a DataTable to store the fetched data
                DataTable foodItemsTable = new DataTable();

                // Your connection string - Update this with your actual connection string
                string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to fetch data from FoodItems table
                    string query = "SELECT FoodID, FoodName, QuantityAvailable FROM FoodItems";

                    // Use SqlDataAdapter to fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(foodItemsTable);
                }

                // Set the DataTable as the DataSource for the DataGridView
                guna2DataGridView.DataSource = foodItemsTable;

                // Explicitly set column names
                guna2DataGridView.Columns["FoodID"].HeaderText = "Food ID";
                guna2DataGridView.Columns["FoodName"].HeaderText = "Food Name";
                guna2DataGridView.Columns["QuantityAvailable"].HeaderText = "Quantity Available";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAndDisplayOrderData()
        {
            try
            {
                // Create a DataTable to store the fetched data
                DataTable ordersTable = new DataTable();

                // Your connection string - Update this with your actual connection string
                string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to fetch data from Orders table
                    string query = "SELECT OrderID, UserName, FoodName, Quantity, Price FROM Orders";

                    // Use SqlDataAdapter to fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(ordersTable);
                }

                // Set the DataTable as the DataSource for the DataGridView
                guna2DataGridView1.DataSource = ordersTable;

                // Optional: You can set column names if you want
                guna2DataGridView1.Columns["OrderID"].HeaderText = "Order ID";
                guna2DataGridView1.Columns["UserName"].HeaderText = "User Name";
                guna2DataGridView1.Columns["FoodName"].HeaderText = "Food Name";
                guna2DataGridView1.Columns["Quantity"].HeaderText = "Quantity";
                guna2DataGridView1.Columns["Price"].HeaderText = "Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Visible = true;
            guna2DataGridView.Visible = true;
            guna2HtmlLabel3.Visible = false;
            guna2DataGridView1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel3.Visible = true;
            guna2DataGridView1.Visible = true;
            guna2HtmlLabel1.Visible = false;
            guna2DataGridView.Visible = false;
        }
    }
}
