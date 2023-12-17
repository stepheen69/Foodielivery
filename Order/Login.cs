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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Order.Model;

namespace Order
{
    public partial class Login : Form
    {

        private string connectionString = "Data Source=DESKTOP-TILM0PL;Initial Catalog=Final;Integrated Security=True";
        private static string loggedInUsername;


        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            checkloginPass.CheckedChanged += checkloginPass_CheckedChanged;
            LoginSign.Click +=LoginSign_Click;


       
        }


        private void checkloginPass_CheckedChanged(object sender, EventArgs e)
        {
            textloginPass.PasswordChar = checkloginPass.Checked ? '\0' : '*';
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textloginName.Text;
            string password = textloginPass.Text;
            string Usertype = combologinType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Usertype))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Pass, Usertype FROM UserAccount WHERE Fullname = @Username";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Pass"].ToString().Trim();
                            string storedUserType = reader["Usertype"].ToString().Trim();

                            if (password == storedPassword)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                                loggedInUsername = username;
                                // Show the corresponding form based on userType
                                switch (storedUserType)
                                {
                                    case "Customer":
                                        LogUserLogin(username, "Customer");
                                        User user = new User();
                                        user.Show();
                                        break;
                                    case "Admin":
                                        LogUserLogin(username, "Admin");
                                        Admin adminForm = new Admin();
                                        adminForm.Show();
                                        break;
                                    case "Seller":
                                        LogUserLogin(username, "Seller");
                                        Seller sellerForm = new Seller();
                                        sellerForm.Show();
                                        break;
                                    case "DeliveryDriver":
                                        LogUserLogin(username, "DeliveryDriver");
                                        DeliveryDriver deliveryDriverForm = new DeliveryDriver();
                                        deliveryDriverForm.Show();
                                        break;
                                    default:
                                        MessageBox.Show("Invalid userType", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }

                                // Hide the Login form
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Function to log user login in the database
        // Function to log user login in the database
        private void LogUserLogin(string username, string userType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the UserLogins table exists, if not, create it (this should only be done once)
                CheckAndCreateUserLoginsTable(connection);

                string insertQuery = "INSERT INTO AdminView (Username, UserType, LoginTime) VALUES (@Username, @UserType, @LoginTime)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@UserType", userType);
                    command.Parameters.AddWithValue("@LoginTime", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Function to check and create UserLogins table if it doesn't exist
        private void CheckAndCreateUserLoginsTable(SqlConnection connection)
        {
            string checkTableQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserAccount') " +
                                     "BEGIN " +
                                     "CREATE TABLE UserLogins (" +
                                     "    Id INT PRIMARY KEY IDENTITY(1,1)," +
                                     "    Username NVARCHAR(255) NOT NULL," +
                                     "    UserType NVARCHAR(50) NOT NULL," +
                                     "    LoginTime DATETIME NOT NULL" +
                                     "); " +
                                     "END";

            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public string GetLoggedInUsername()
        {
            return loggedInUsername;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginSign_Click(object sender, EventArgs e)
        {
            SignupForm signupform = new SignupForm();
            this.Hide();

            signupform.FormClosed += (s, args) =>
            {
                this.Close();
            };

            signupform.ShowDialog();
        }
    }
    }
