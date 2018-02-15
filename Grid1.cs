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
    public partial class Grid1 : Form
    {
        public Grid1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                SqlConnection con = new SqlConnection("Data Source=DESKTOP-63NM2GT\\SQLEXPRESS;Initial Catalog=NewRailway;Integrated Security=True;Pooling=False");//connection name
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Train where TrainNo=@trainno ", con);
                cmd.Parameters.AddWithValue("@trainno", textBox1.Text.Trim());
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
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Traininfo ti = new Traininfo();
            this.Hide();
            ti.Show();
        }
    }
}
