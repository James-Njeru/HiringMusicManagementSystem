using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HiringMusicDatabaseManagementSystem
{
    public partial class Customer : Form
    {
        String query;
        DataTable dt;
        int index = 0;

        public Customer()
        {
            InitializeComponent();
        }

        public void showData(int position)
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                MySqlDataAdapter da;
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                //Read the data and store them in the list
                /*TextBox5.Text = dt.Rows(position)(0).ToString();
                TextBox1.Text = dt.Rows(position)(1).ToString();
                TextBox4.Text = dt.Rows(position)(2).ToString();
                TextBox3.Text = dt.Rows(position)(3).ToString();
                TextBox2.Text = dt.Rows(position)(4).ToString();*/

                connect.CloseConnection();
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "insert into customer values('" + TextBox5.Text + "','" + TextBox1.Text + "','" + TextBox4.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record Successfully saved!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {

                    this.TextBox5.Text = dataReader["customer_id"].ToString();
                    this.TextBox1.Text = dataReader["customer_name"].ToString();
                    this.TextBox4.Text = dataReader["customer_number"].ToString();
                    this.TextBox3.Text = dataReader["customer_email"].ToString();
                    this.TextBox2.Text = dataReader["password"].ToString();
                }

                connect.CloseConnection();
            }
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            index = dt.Rows.Count - 1;
            showData(index);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            index = dt.Rows.Count + 1;
            showData(index);
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            index -= 1;
            showData(index);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "update customer set customer_id='" + TextBox5.Text + "', customer_name='" + TextBox1.Text + "', customer_number='" + TextBox4.Text + "', customer_email='" + TextBox3.Text + "', password='" + TextBox2.Text + "' where customer_id='" + TextBox5.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";

            MessageBox.Show("Record Reset");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "delete from customer where customer_id='" + TextBox5.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    MessageBox.Show("Record deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
