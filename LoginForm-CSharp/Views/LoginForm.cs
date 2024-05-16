using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm_CSharp.Views;
using MySqlConnector;

namespace LoginForm_CSharp
{
    public partial class LoginForm : Form
    {
        // SQL connection
        MySqlConnection connection = new MySqlConnection("server=localhost;database=c_form;port=3306;username=root;password=");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // If blank form is submitted 
                if (string.IsNullOrEmpty(LogUsernameText.Text) || string.IsNullOrEmpty(LogPasswordText.Text))
                {
                    MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open SQL connection
                connection.Open();
                string selectQuery = "SELECT * FROM users WHERE Username = @Username AND Password = @Password";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", LogUsernameText.Text);
                command.Parameters.AddWithValue("@Password", LogPasswordText.Text);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    string loggedUserName = LogUsernameText.Text;
                    DashboardForm dashboardForm = new DashboardForm();
                    dashboardForm.Show();
                     // Close the login form after opening dashboard
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void GoToRegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Show(); // Show the login form again after registering
        }
    }
}
