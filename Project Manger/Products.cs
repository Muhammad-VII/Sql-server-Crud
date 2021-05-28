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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            String insert = "insert into Product (ProductID,ProductName) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
            con.Open();
            SqlCommand com = new SqlCommand(insert, con);
            com.ExecuteReader();
            con.Close();

            MessageBox.Show("Data Saved Successfully");
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand upcom = new SqlCommand();
            upcom.CommandText = "update Product set ProductName = '" + textBox2.Text + "', Quantity = '" + textBox3.Text + "', Product_Type = '" + textBox4.Text + "', Price = '" + textBox6.Text + "'  where ProductID = '" + textBox1.Text + "'";
            upcom.Connection = con;
            upcom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Command Executed successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection c;
            c = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            c.Open();
            SqlCommand selectcmnd = new SqlCommand();
            selectcmnd.CommandText = "Execute Orders_Product @OrderID ='" + textBox1.Text + "'";
            selectcmnd.Connection = c;
            SqlDataReader r = selectcmnd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            dataGridView1.DataSource = t;
            c.Close();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand DelCom = new SqlCommand();
            DelCom.CommandText = "Delete from Product where ProductID = '" + textBox1.Text + "'";
            DelCom.Connection = con;
            DelCom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted Successfully");
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            String insert = "insert into Product (ProductID,ProductName,Price,Quantity,Product_Type) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            con.Open();
            SqlCommand com = new SqlCommand(insert, con);
            com.ExecuteReader();
            con.Close();

            MessageBox.Show("Data Saved Successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

            textBox1.Enabled = false;
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(ProductID)+1 from Product";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button5.Enabled = true;
                textBox1.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                button5.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button6.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
                textBox3.Enabled = false;
                textBox6.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;

            }
            textBox1.Enabled = false;
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(ProductID)+1 from Product";
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

        private void Products_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox6.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;    
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                button4.Enabled = true;
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button4.Enabled = false;
                textBox3.Enabled = false;
                textBox6.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
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
    }
}
