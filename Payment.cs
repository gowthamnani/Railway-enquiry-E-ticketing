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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                //sqcon.Close();
                SqlCommand cmd1 = new SqlCommand("insert into Booked(Total,Status) values(@tot,'CNF') where TicketNo=@tktt", sqcon);
                cmd.Parameters.AddWithValue("@tot", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@tktt", textBox2.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                int i = cmd.ExecuteNonQuery();
                sqcon.Close();
            }


            else
            {
                MessageBox.Show("ENTER VALID CREDENTIAL");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {



                SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
                con.Open();
                SqlCommand cmd = new SqlCommand("select TicketNo from Booked where username=@username", con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());

               
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }

            catch

            {

                MessageBox.Show("No Tickets Exist For This User ");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            try
            {



                SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Booked where TicketNo=@tktno ", con);
                cmd.Parameters.AddWithValue("@tktno", textBox2.Text.Trim());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView2.DataSource = ds.Tables["ss"];
                con.Close();

            }

            catch

            {

                MessageBox.Show("NO RECORD FOUND    ");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HAPPY JOURNEY , KEEP THE TRAIN AND RAILWAY STATION CLEAN");
            this.Close();
        }
    }
}
