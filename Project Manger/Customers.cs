using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Manger
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand DelCom = new SqlCommand();
            DelCom.CommandText = "Delete from Customers where Customer_ID = ('" + textBox1.Text + "')";
            DelCom.Connection = con;
            DelCom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted Successfully");
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            String insert = "insert into Customers (Customer_ID,Email,FName,LName,Ct_address,PhoneNumber,Gender,Age) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox4.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
            con.Open(); 
            SqlCommand com = new SqlCommand(insert, con);
            com.ExecuteReader();
            con.Close();

            MessageBox.Show("Data Saved Successfully");           
            textBox1.Clear();           
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();


            textBox1.Enabled = false;
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(Customer_ID)+1 from Customers";
            con1.Open();
            SqlCommand com1 = new SqlCommand(select1, con1);
            SqlDataReader dr1;
            dr1 = com1.ExecuteReader();
            string newdeptid = "1";

            if (dr1.Read())
            {
                if (dr1[0].ToString() != "")
                {
                    newdeptid = dr1[0].ToString();
                }
                textBox1.Text = newdeptid;
            }
            con1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection c;
            c = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            c.Open();
            SqlCommand selectcmnd = new SqlCommand();
            selectcmnd.CommandText = "Execute Cus_product @CustomerID ='" + textBox1.Text + "'";
            selectcmnd.Connection = c;
            SqlDataReader r = selectcmnd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            dataGridView1.DataSource = t;
            r.Close();
            c.Close();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=TrueData Source=.;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand upcom = new SqlCommand();
            upcom.CommandText = "update Customers set Email = '" + textBox2.Text + "', FName = '" + textBox3.Text + "', LName = '" + textBox5.Text + "', Ct_address = '" + textBox6.Text + "', PhoneNumber = '" + textBox4.Text + "', Gender = '" + textBox7.Text + "', Age = '" + textBox8.Text + "'  where Customer_ID = '" + textBox1.Text + "'";
            upcom.Connection = con;
            upcom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Command Executed successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
           
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;

            }
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button5, "Search For Customer Data");
            toolTip1.SetToolTip(this.button1, "Insert New Data On Customers Table");
            toolTip1.SetToolTip(this.button3, "Delete all customer data using his/her id");
            toolTip1.SetToolTip(this.button4, "Update Customer's Email using his/her id");
            toolTip1.SetToolTip(this.button2, "Go back to the main menu");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button5.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;

            }
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(Customer_ID)+1 from Customers";
            con1.Open();
            SqlCommand com1 = new SqlCommand(select1, con1);
            SqlDataReader dr1;
            dr1 = com1.ExecuteReader();
            string newdeptid = "1";

            if (dr1.Read())
            {
                if (dr1[0].ToString() != "")
                {
                    newdeptid = dr1[0].ToString();
                }
                textBox1.Text = newdeptid;
            }
            con1.Close();
            if (checkBox2.Checked == false)
            {
                textBox1.Clear();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                button4.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;              
                textBox3.Enabled = true;              
                textBox4.Enabled = true;              
                textBox5.Enabled = true;              
                textBox6.Enabled = true;              
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
