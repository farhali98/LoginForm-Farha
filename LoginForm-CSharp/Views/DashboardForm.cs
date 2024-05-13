using MySql.Data.MySqlClient;
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

namespace LoginForm_CSharp.Views
{
    public partial class DashboardForm : Form
    {
        private readonly string username;
        MySqlConnection connection = new MySqlConnection("server=localhost;database=form;port=3306;username=root;password=");

        MySqlCommand command;
        MySqlDataReader dr;

        public DashboardForm(string username)
        {
           
        }

       
        

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_student studenForm = new Add_student();
            studenForm.Show();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Define your SQL query
                string query = "SELECT * FROM students";

                // Create a command object with the query and connection
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and get a reader
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Clear the existing items in the ListBox
                    listBox1.Items.Clear();

                    // Loop through the result set
                    while (reader.Read())
                    {
                        // Assuming the student's name is in a column named "Name"
                        // Add each student's name to the ListBox
                        listBox1.Items.Add(reader["fname"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Close the form or handle the exception appropriately
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
