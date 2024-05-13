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
        //sql connection
        MySqlConnection connection = new MySqlConnection("server=localhost;database=form;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try 

            { 
                // if blank form is submitted 
                if (string.IsNullOrEmpty(LogUsernameText.Text) || string.IsNullOrEmpty(LogPasswordText.Text))
                {
                    MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //begin sql connection
                connection.Open();
                string selectQuery = "SELECT * FROM users WHERE Username = @Username AND Password = @Password";
                command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", LogUsernameText.Text);
                command.Parameters.AddWithValue("@Password", LogPasswordText.Text);
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    string LoggedUserName = LogUsernameText.Text;
                    DashboardForm dashboardForm = new DashboardForm(LoggedUserName);
                    dashboardForm.Show();
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
            registerForm.Show();
        }
    }
}
