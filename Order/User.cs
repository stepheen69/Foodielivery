using Guna.UI2.WinForms;
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
    public partial class User : Form
    {
      
        private bool isBelowButtonClicked = false;
        private Login loginFormInstance = new Login();
        private decimal totalOrderPrice = 0;
        private Dictionary<string, int> foodPrices;


        public User()
        {
            InitializeComponent();
            InitializeFoodPrices();
        }
        private void InitializeFoodPrices()
        {
            foodPrices = new Dictionary<string, int>()
            {
                { label1.Text, 120 },
                { label3.Text, 60 },
                { label6.Text, 80 },
                { label7.Text, 60 },
                { label9.Text, 130 },
                { label11.Text, 50 },
                // Add more food items as needed
            };
        }

        private void btnAbove_Click(object sender, EventArgs e)
        {
            if (!isBelowButtonClicked)
            {
                // Adjust the Top property to move PictureBox2 up
                pictureBox2.Top -= 20;  // You can adjust the value based on your layout

                // Hide PictureBox1
                pictureBox1.Visible = false;

                // Disable the "Above" button
                btnAbove.Enabled = false;

                // Enable the "Below" button
                btnBelow.Enabled = true;

                // Update the state
                isBelowButtonClicked = true;
            }
        }

        private void btnBelow_Click(object sender, EventArgs e)
        {
            if (isBelowButtonClicked)
            {
                // Show PictureBox1
                pictureBox1.Visible = true;

                // Adjust the Top property to move PictureBox2 down
                pictureBox2.Top += 20;  // You can adjust the value based on your layout

                // Enable the "Above" button
                btnAbove.Enabled = true;

                // Disable the "Below" button
                btnBelow.Enabled = false;

                // Update the state
                isBelowButtonClicked = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guna2GroupBox1.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Success");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = true;
        }


        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            testButton.Visible = true;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label1.Text;
                    int quantity = int.Parse(guna2ComboBox1.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label1.Text, int.Parse(guna2ComboBox1.SelectedItem.ToString()));
                    testButton.Visible = false;
                    guna2Panel1.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();
                       
                            if (orderProcessed)
                            {
                               
                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }
                        
                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel2.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label3.Text;
                    int quantity = int.Parse(guna2ComboBox2.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label3.Text, int.Parse(guna2ComboBox2.SelectedItem.ToString()));
                    guna2Button2.Visible = false;
                    guna2Panel2.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();

                            if (orderProcessed)
                            {

                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            guna2Button2.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guna2Button2.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string usernameToRetrieve = loginFormInstance.GetLoggedInUsername();

            guna2Panel4.Visible = true;
            // Fetch data from the Orders table
            List<OrderItem> orderItems = GetOrderItemsFromDatabase(usernameToRetrieve);

            // Display the data in guna2Panel4
            DisplayOrderItems(orderItems);
        }
        private List<OrderItem> GetOrderItemsFromDatabase(string username)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            // Connection string
            string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Select query to retrieve data from the Orders table for a specific user
                string selectQuery = "SELECT UserName, FoodName, Quantity, Price FROM Orders WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Read data from the reader
                            string foodName = reader["FoodName"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            // Create OrderItem object and add to the list
                            OrderItem orderItem = new OrderItem(username, foodName, quantity, price);
                            orderItems.Add(orderItem);
                        }
                    }
                }
            }

            return orderItems;
        }


        private void DisplayOrderItems(List<OrderItem> orderItems)
        {
            // Clear previous controls in the panel
            guna2Panel4.Controls.Clear();

            totalOrderPrice = 0;

            // Display data in guna2Panel4
            int yOffset = 20; // Initial Y offset

           
            foreach (var orderItem in orderItems)
            {
                // Create labels to display order information
                Label lblOrder = new Label();
              //  lblOrder.Text = $"{orderItem.UserName} ordered {orderItem.Quantity} {orderItem.FoodName} for {orderItem.Price:C}";
                lblOrder.Text = $"{orderItem.FoodName} x {orderItem.Quantity}";
               // lblOrder.Location = new Point(20, yOffset);
                lblOrder.AutoSize = true;
                lblOrder.Font = new Font("Courier New", 12, FontStyle.Bold);

                int xPos = (guna2Panel4.Width - lblOrder.Width) / 2;

                // Set the location of the label
                lblOrder.Location = new Point(xPos, yOffset);

                // Add label to the panel
                guna2Panel4.Controls.Add(lblOrder);

                // Increment Y offset for the next label
                yOffset += lblOrder.Height + 5;

                totalOrderPrice += orderItem.Price;


            }

            Label lblSubtotal = new Label();
            lblSubtotal.Text = $"\u20B1{totalOrderPrice:N2}";
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Courier New", 20, FontStyle.Bold);

            // Set the location of the subtotal label beside guna2HtmlLabel4
            lblSubtotal.Location = new Point(guna2HtmlLabel4.Right + 20, guna2HtmlLabel4.Top);

            // Calculate total including a fixed amount (50)
            decimal total = totalOrderPrice + 50;

            Label lblTotal = new Label();
            lblTotal.Text = $"\u20B1{total:N2}";
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Courier New", 20, FontStyle.Bold);

            // Set the location of the total label beside guna2HtmlLabel4
            lblTotal.Location = new Point(guna2HtmlLabel2.Right + 20, guna2HtmlLabel2.Top);

            guna2Panel4.Controls.Add(guna2HtmlLabel1);
            guna2Panel4.Controls.Add(guna2Button6);
            guna2Panel4.Controls.Add(guna2Button13);
            guna2Panel4.Controls.Add(guna2HtmlLabel2);
            guna2Panel4.Controls.Add(guna2HtmlLabel3);
            guna2Panel4.Controls.Add(guna2HtmlLabel4);
            guna2Panel4.Controls.Add(lblSubtotal);
            guna2Panel4.Controls.Add(lblTotal);

        }

        // Define a class to represent an order item
        public class OrderItem
        {
            public string UserName { get; set; }
            public string FoodName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public OrderItem(string userName, string foodName, int quantity, decimal price)
            {
                UserName = userName;
                FoodName = foodName;
                Quantity = quantity;
                Price = price;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Get the username for whom orders should be deleted
            string usernameToDelete = loginFormInstance.GetLoggedInUsername();

            if (string.IsNullOrEmpty(usernameToDelete))
            {
                MessageBox.Show("Username is null. Cannot proceed with the deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Connection string
            string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // DELETE query to remove orders for the specific user
                string deleteQuery = "DELETE FROM Orders WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", usernameToDelete);

                    // Execute the DELETE query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Orders for {usernameToDelete} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        guna2Panel4.Visible = false;
                        // Refresh the displayed order items
                        // List<OrderItem> orderItems = GetOrderItemsFromDatabase();
                        //  DisplayOrderItems(orderItems);
                    }
                    else
                    {
                        MessageBox.Show($"No orders found for {usernameToDelete}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            guna2Button3.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            guna2Button8.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            guna2Button10.Visible = true;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2Panel7.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label6.Text;
                    int quantity = int.Parse(guna2ComboBox3.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label6.Text, int.Parse(guna2ComboBox3.SelectedItem.ToString()));
                    guna2Button3.Visible = false;
                    guna2Panel3.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();

                            if (orderProcessed)
                            {

                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel3.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            guna2Button12.Visible = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2Panel5.Visible = true;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2Panel6.Visible = true;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label7.Text;
                    int quantity = int.Parse(guna2ComboBox4.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label7.Text, int.Parse(guna2ComboBox4.SelectedItem.ToString()));
                    guna2Button8.Visible = false;
                    guna2Panel5.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();

                            if (orderProcessed)
                            {

                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label9.Text;
                    int quantity = int.Parse(guna2ComboBox5.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label9.Text, int.Parse(guna2ComboBox5.SelectedItem.ToString()));
                    guna2Button10.Visible = false;
                    guna2Panel6.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();

                            if (orderProcessed)
                            {

                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                string username = loginFormInstance.GetLoggedInUsername();
                if (username != null)
                {
                    string foodName = label11.Text;
                    int quantity = int.Parse(guna2ComboBox6.SelectedItem.ToString());
                    int price = foodPrices[foodName] * quantity;
                    string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
                    bool orderProcessed = ProcessOrder(label11.Text, int.Parse(guna2ComboBox6.SelectedItem.ToString()));
                    guna2Button12.Visible = false;
                    guna2Panel7.Visible = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Orders (UserName, FoodName, Quantity, Price) VALUES (@UserName, @FoodName, @Quantity, @Price)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Ensure @UserName is supplied with a value
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@FoodName", foodName);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Price", price);

                            command.ExecuteNonQuery();

                            if (orderProcessed)
                            {

                                MessageBox.Show($"You ordered {quantity} {foodName}, it cost {price}.");
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("LoginFormInstance is null. Cannot proceed with the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            guna2Panel4.Visible = false;
        }

        private bool ProcessOrder(string foodName, int quantity)
        {
            // Check if there's enough quantity available
            if (IsQuantityAvailable(foodName, quantity))
            {
                // Proceed with the order processing logic
                // ...

                // Update the quantity available in the database
                UpdateQuantityAvailable(foodName, quantity);

                return true;
            }
            else
            {
                MessageBox.Show($"Sorry, {foodName} is out of stock or has insufficient quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        private bool IsQuantityAvailable(string foodName, int quantity)
        {
            // Retrieve the current quantity available from the database
            int currentQuantity = GetQuantityAvailableFromDatabase(foodName);

            // Check if there's enough quantity available
            return currentQuantity >= quantity;
        }

        private int GetQuantityAvailableFromDatabase(string foodName)
        {
            int quantityAvailable = 0;

            // Connection string
            string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

            // SQL query to retrieve quantity available for the specified food item
            string selectQuery = "SELECT QuantityAvailable FROM FoodItems WHERE FoodName = @FoodName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    // Add parameter to the command
                    command.Parameters.AddWithValue("@FoodName", foodName);

                    // Execute the query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows returned
                        if (reader.Read())
                        {
                            // Read the quantity available from the reader
                            quantityAvailable = Convert.ToInt32(reader["QuantityAvailable"]);
                        }
                    }
                }
            }

            return Math.Max(0, quantityAvailable);
        }


        private void UpdateQuantityAvailable(string foodName, int quantity)
        {
            try
            {
                // Connection string
                string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";

                // SQL query to update quantity available for the specified food item
                string updateQuery = "UPDATE FoodItems SET QuantityAvailable = QuantityAvailable - @Quantity WHERE FoodName = @FoodName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@FoodName", foodName);
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

    }

}
