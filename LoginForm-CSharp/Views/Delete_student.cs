using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm_CSharp.Views
{
    public partial class Delete_student : Form
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;database=c_form;port=3306;username=root;password=");
        public Delete_student()
        {
            InitializeComponent();
        }

        private void STUDENT_ID_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the ID from the label
                int studentIdToDelete = Convert.ToInt32(textBox2.Text);

                // Open the connection
                connection.Open();

                // Define the SQL query to delete the student with the given ID
                string deleteQuery = "DELETE FROM students WHERE student_id = @StudentId";

                // Create a command object with the query and connection
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@StudentId", studentIdToDelete);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally, update the list box or any other UI element to reflect the deletion
                }
                else
                {
                    MessageBox.Show("No student found with the given ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
