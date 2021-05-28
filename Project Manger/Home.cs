using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Manger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders obj = new Orders();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products obj = new Products();
            obj.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Refunds obj = new Refunds();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {           
                DialogResult dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Mange Customers Table");
            toolTip1.SetToolTip(this.button2, "Mange Orders Table");
            toolTip1.SetToolTip(this.button3, "Mange Product Table");
            toolTip1.SetToolTip(this.button4, "Mange Refunds Table");
            toolTip1.SetToolTip(this.button5, "Exit Project Manger");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Shippers obj = new Shippers();
            obj.Show();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

    }
        
}

