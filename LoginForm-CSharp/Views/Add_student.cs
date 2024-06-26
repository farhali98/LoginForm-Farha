﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm_CSharp.Views
{
    public partial class Add_student : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=c_form;port=3306;username=root;password=");
        public Add_student()
        {
            InitializeComponent();
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Student added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                // Get the ID from the label
                int age = Convert.ToInt32(textBox2.Text);
                string fname = Convert.ToString(textBox1.Text);
                string form = Convert.ToString(textBox3.Text);
                int phone_number = Convert.ToInt32(textBox4.Text);


                // Open the connection
                connection.Open();

                // Define the SQL query to delete the student with the given ID
                string deleteQuery = "INSERT INTO students (fname, age, class, phone_number) VALUES (@Fname, @age, @Form, @PhoneNumber)";

                // Create a command object with the query and connection
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Fname", fname);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@Form", form);
                command.Parameters.AddWithValue("@PhoneNumber", phone_number);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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








            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Add_student_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
