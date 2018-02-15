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
    public partial class Traininfo : Form
    {
        public Traininfo()
        {
            InitializeComponent();
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
                SqlCommand cmd = new SqlCommand("select * from Stcode ", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
            //Grid1 g1 = new Grid1();
            //this.Close();
            //g1.Show();
        }





        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
                con.Open();
                //SqlCommand cmd = new SqlCommand("SELECT * from TrainBW where SFrom=@sfrom and DTo=@dto", con);
                SqlCommand cmd = new SqlCommand("BWTrain", con); // using BWTrain Stored procedure
                cmd.Parameters.AddWithValue("@sfrom", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dto", textBox2.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Grid1 g1 = new Grid1();
            
            g1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Grid2 g2 = new Grid2();

            g2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Grid3 g3 = new Grid3();

            g3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Booking bo = new Booking();
            bo.Show();

        }
    }
}
