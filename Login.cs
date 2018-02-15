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

namespace RailwayManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You will be entering Signup page shortly");
            Signup su = new Signup();
            this.Hide();
            su.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlConnection sqcon = new SqlConnection(@"Data Source=DESKTOP-63NM2GT\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");
            
            SqlCommand cmd = new SqlCommand("select  * from Account where username=@username and password=@password", sqcon);
            cmd.Parameters.AddWithValue("@username", usernameTB.Text.Trim());
            cmd.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqcon.Open();
            int i = cmd.ExecuteNonQuery();
            sqcon.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("LOGIN SUCCESSFUL");
                {
                    Traininfo ti = new Traininfo();
                    this.Hide();
                    ti.Show();                          //goes to Traininfo form
                }
            }


            else
            {
                MessageBox.Show("check username and password OR Signup");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SEE YOU SOON!!!!");
            this.Close();
        }
        private void usernameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqcon = new SqlConnection(@"Data Source=DESKTOP-63NM2GT\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");

            SqlCommand cmd = new SqlCommand("select  * from Account where username=@username and password=@password", sqcon);
            cmd.Parameters.AddWithValue("@username", usernameTB.Text.Trim());
            cmd.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqcon.Open();
            int i = cmd.ExecuteNonQuery();
            sqcon.Close();
            if (dt.Rows.Count > 0)
            {
                Payment p1 = new Payment();
                this.Hide();
                p1.Show();
            }
            else
            {
                MessageBox.Show("CHECK USER_NAME AND PASSWORD OR SIGN_UP");
            }


        }
    }
}
