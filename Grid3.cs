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
    public partial class Grid3 : Form
    {
        public Grid3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
                con.Open();
                SqlCommand cmd = new SqlCommand("select Coach,Fare from NewFare where TrainNo=@trainno and src=@src and dest=@dest", con);
                cmd.Parameters.AddWithValue("@trainno", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@src", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dest", textBox3.Text.Trim());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }

            catch

            {

                MessageBox.Show("TrainNo Does Not Match With Station Code");

            }
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
            //SqlCommand com;
            //string str;
            //con.Open();
            //str = "select Fare from Newfare where TrainNo='12005' and src='MYS' and dest='UBL' and Coach='AC'";
            //com = new SqlCommand(str, con);
            //SqlDataReader rd = com.ExecuteReader();
            //if (rd.Read())
            //{
            //    textBox4.Text = rd["Fare"].ToString();
            //    rd.Close();                                       /// CODED While Testing
            //    con.Close();
            //}


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
