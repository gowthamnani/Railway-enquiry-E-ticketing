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
    public partial class Signup : Form

    {
        public Signup()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                                       
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Signup", con);
            cmd.CommandType = CommandType.StoredProcedure;   // using Signup stored procedure
            //SqlCommand cmd = new SqlCommand("insert into Account(username,password,emailid) values(@username,@password,@emailid)",con);

            cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@emailid", textBox3.Text.Trim());
            //cmd.Parameters.AddWithValue("@dateofbirth", textBox4.Text.Trim());
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("ENTER VALID CREDENTIAL");
                //this.Show();

            }

            else
            {

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    MessageBox.Show("Registred Successfully.Now Login With To Your Account");
                    Login lo = new Login();
                    this.Hide();
                    lo.Show();                          //code to go back to login page
                }
                else
                {
                    MessageBox.Show("REGISTRATION UNSUCCESSFULL");
                }



            }
            





            //SqlCommand cmd;
            //con.Open();
            //string s = "insert into Account values(@p1,@p2,@p3,@p4)";
            //cmd = new SqlCommand(s, con);
            //cmd.Parameters.AddWithValue("@p1", textBox1.Text.Trim());
            //cmd.Parameters.AddWithValue("@p2", textBox2.Text.Trim());
            //cmd.Parameters.AddWithValue("@p3", textBox3.Text.Trim());
            //cmd.Parameters.AddWithValue("@p4", textBox4.Text.Trim());
            //cmd.CommandType = CommandType.Text;
            //int i = cmd.ExecuteNonQuery();
            //con.Close();
            //if(i!=0)
            //MessageBox.Show("Registred Successfully.Now Login With To Your Account");


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            this.Hide();
            lo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select  * from Account where username=@username", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("USER_NAME EXIST,CHOOSE OTHER");
            }
            else
            {
                MessageBox.Show("Continue With The registration");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
