using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginForm_CSharp.Views
{
    public partial class update_stuent : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=c_form;port=3306;username=root;password=");
        public update_stuent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the ID from the label
                int id = Convert.ToInt32(textBox1.Text);
                string fname = Convert.ToString(textBox2.Text);
            
                int phone_number = Convert.ToInt32(textBox3.Text);


                // Open the connection
                connection.Open();

                // Define the SQL query to delete the student with the given ID
                string deleteQuery = "UPDATE students\r\nSET fname = @NewFname, phone_number = @NewPhoneNumber\r\nWHERE id = @IdToUpdate;";

                // Create a command object with the query and connection
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@IdToUpdate", id);
                command.Parameters.AddWithValue("@NewFname", fname);
                command.Parameters.AddWithValue("@NewPhonenumber", phone_number);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally, update the list box or any other UI element to reflect the deletion
                }
                else
                {
                    MessageBox.Show("check details if entered correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
