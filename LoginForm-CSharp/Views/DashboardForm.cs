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
        private MySqlConnection connection = new MySqlConnection("server=localhost;database=c_form;port=3306;username=root;password=");

        public DashboardForm()
        {
            InitializeComponent();
             // Store the logged-in username
            PopulateListBox(); // Populate the list box when the form is loaded
        }

        private void PopulateListBox()
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
                        // Assuming the student's name is in a column named "fname"
                        string studentInfo = $"{reader["student_id"]} - {reader["fname"]}";

                        // Add the concatenated string to the ListBox
                        listBox1.Items.Add(studentInfo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_student studenForm = new Add_student();
            studenForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete_student studenForm = new Delete_student();
            studenForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_stuent studenForm = new update_stuent();
            studenForm.Show();
        }
    }
}
