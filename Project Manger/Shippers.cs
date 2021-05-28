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
    public partial class Shippers : Form
    {
        public Shippers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            String insert = "insert into Shippers (Shipper_ID,Shipper_Name,CompanyName,Age,Gender,Shipper_PNumber) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "','" + textBox7.Text + "')";
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
            textBox7.Clear();

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(Shipper_ID)+1 from Shippers";
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
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand DelCom = new SqlCommand();
            DelCom.CommandText = "Delete from Shippers where Shipper_ID = ('" + textBox1.Text + "')";
            DelCom.Connection = con;
            DelCom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted Successfully");
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand upcom = new SqlCommand();
            upcom.CommandText = "update Shippers set Shipper_Name = '" + textBox2.Text + "', CompanyName = '" + textBox3.Text + "', Age = '" + textBox5.Text + "', Shipper_PNumber = '" + textBox7.Text + "', Gender = '" + textBox4.Text + "' where Shipper_ID = '" + textBox1.Text + "'";
            upcom.Connection = con;
            upcom.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Command Executed successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection c;
            c = new SqlConnection("Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True");
            c.Open();
            SqlCommand selectcmnd = new SqlCommand();
            selectcmnd.CommandText = "select * from Shippers where Shipper_ID = '" + textBox1.Text + "'";
            selectcmnd.Connection = c;
            SqlDataReader r = selectcmnd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            dataGridView1.DataSource = t;
            c.Close();
            textBox1.Clear();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox1.Enabled = true;
                button3.Enabled = true;

            }
            else
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void Shippers_Load(object sender, EventArgs e)
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
            textBox7.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button4.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox7.Enabled = true;

            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button4.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox7.Enabled = true;

            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox7.Enabled = false;
            }

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "Data Source=MUZI\\SQLEXPRESS;Initial Catalog=Online_Retail;Integrated Security=True";
            string select1 = "select MAX(Shipper_ID)+1 from Shippers";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
