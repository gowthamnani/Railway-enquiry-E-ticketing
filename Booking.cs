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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }



        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

                SqlConnection sqcon = new SqlConnection(@"Data Source=DESKTOP-63NM2GT\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");

                SqlCommand cmd = new SqlCommand("select  * from Account where username=@username and password=@password", sqcon);
                cmd.Parameters.AddWithValue("@username", textBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textBox7.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqcon.Open();
                int i = cmd.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
               


                try
                {
                    SqlCommand cmd2 = new SqlCommand("select Fare from Newfare where TrainNo=@trainno and src=@src and dest=@dest and Coach=@coach", sqcon);

                    cmd2.CommandType = CommandType.Text;
                    //  string str;

                    //str = "select Fare from Newfare where TrainNo=@trainno and src=@src and dest=@dest and Coach=@coach";
                    cmd2.Parameters.AddWithValue("@trainno", textBox1.Text.Trim());
                    cmd2.Parameters.AddWithValue("@src", textBox4.Text.Trim());
                    cmd2.Parameters.AddWithValue("@dest", textBox3.Text.Trim());
                    cmd2.Parameters.AddWithValue("@coach", listBox1.Text);
                    //cmd2.Parameters.AddWithValue("@p", listBox2.Text);

                    SqlDataReader rd = cmd2.ExecuteReader();
                    if (rd.Read())
                    {
                        textBox9.Text = rd["Fare"].ToString();
                        rd.Close();
                        //sqcon.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Train OR Station Does NOT Exist");
                }

                try
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Booked(TrainNo,Source,Destination,Coach,No_of_passangers,PassangerName,Passanger_ID,Fare_Per_Head,Mobile_No,username,Status) VALUES(@Trainno,@Source,@Destination,@Coach,@No_of_passangers,@PassangerName,@Passanger_ID,@Fare_Per_Head,@Mobile_No,@username,'CNF')", sqcon);
                    cmd1.CommandType = CommandType.Text;   // using book stored procedure
                                                           //SqlCommand cmd = new SqlCommand("insert into Account(username,password,emailid,dateofbirth) values(@username,@password,@emailid,@dateofbirth)",con);

                    cmd1.Parameters.AddWithValue("@Trainno", textBox1.Text.Trim());
                    cmd1.Parameters.AddWithValue("@Source", textBox4.Text.Trim());
                    cmd1.Parameters.AddWithValue("@Destination", textBox3.Text.Trim());
                    cmd1.Parameters.AddWithValue("@Coach", listBox1.Text);
                    cmd1.Parameters.AddWithValue("@No_of_passangers", listBox2.Text);
                    cmd1.Parameters.AddWithValue("@PassangerName", textBox2.Text);
                    cmd1.Parameters.AddWithValue("@Passanger_ID", textBox5.Text.Trim());
                    // cmd.Parameters.AddWithValue("@Passanger2_ID", textBox7.Text);
                    // cmd.Parameters.AddWithValue("@Passanger3_ID", textBox8.Text);
                    cmd1.Parameters.AddWithValue("@Fare_Per_Head", textBox9.Text.Trim());
                    cmd1.Parameters.AddWithValue("@Mobile_No", textBox14.Text.Trim());
                    cmd1.Parameters.AddWithValue("@username", textBox6.Text.Trim());
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || listBox1.Text == "" || listBox2.Text == "")
                    {
                        MessageBox.Show("Enter a valid Train Credential");
                        //this.Show();
                        return;
                    }

                    else
                    {


                        int j = cmd1.ExecuteNonQuery();
                        sqcon.Close();
                        if (j > 0)
                        {



                        }



                        else
                        {
                            MessageBox.Show("Provide Correct Train Details");
                        }


                    }



                    MessageBox.Show("Processing,Click OK");
                    this.Close();
                    Payment py = new Payment();
                    py.Show();
                }
                catch
                {
                    MessageBox.Show("Train OR Station Does NOT Exist");
                }
            }

            

            else
            {
                MessageBox.Show("check username and password");
            }





        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqcon = new SqlConnection(@"Data Source=DESKTOP-63NM2GT\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");
            sqcon.Open();
            SqlCommand cmd = new SqlCommand("select No_of_passangers*Fare_Per_head as tot from Booked where username=@username and TicketNo=@tkt", sqcon);
            cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@tkt", textBox2.Text.Trim());
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                textBox3.Text = rd["tot"].ToString();
                rd.Close();
                sqcon.Close();
            }


            else
            {
                MessageBox.Show("Enter Valid Credential");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


        
    


       
        
    



                
          