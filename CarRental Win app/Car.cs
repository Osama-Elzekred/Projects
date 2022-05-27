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
using System.Configuration;
namespace CarRental
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        private void button1_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CarTb1 values ('" + RegNumTb.Text + "','" + BrandTb.Text + "','" + ModelTb.Text + "','"+AvailableCb.SelectedItem.ToString()+ "','" + PriceTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Added Successfully");
                    con.Close();
                    disp();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Car_Load(object sender, EventArgs e)
        {
            disp();
           
        }
        public void disp()
        {
            con.Open();
            string quary = "select * from CarTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CarTb1 where RegNum='" + RegNumTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Deleted Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void fillAvailable()
        {
            con.Open();
            string quary = "select Available from CarTb1";
            SqlCommand cmd = new SqlCommand(quary, con);
            
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            //string str = "";
            //foreach (var item in rdr)
            //{
            //    str += (item).ToString()+"  ";
            //}
            //MessageBox.Show(str);
            DataTable dt = new DataTable();
            dt.Columns.Add("Available", typeof(string));
            dt.Load(rdr);
            Search.ValueMember = "Available";
            Search.DataSource = dt;
            con.Close();
        }
        private void CarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNumTb.Text = CarDGV.SelectedRows[0].Cells[0].Value.ToString();
            BrandTb.Text = CarDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarDGV.SelectedRows[0].Cells[2].Value.ToString();
            AvailableCb.SelectedItem = CarDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CarDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CarTb1 set Brand='" + BrandTb.Text + "',Model='" + ModelTb.Text + "',Available='" + AvailableCb.SelectedItem.ToString() + "',Price='" + PriceTb.Text + "' where RegNum='" + RegNumTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Updated Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            disp();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string flag = "";
            if (Search.SelectedItem.ToString()=="Available")
            {
                flag = "YES";
            }
            else
            {
                flag = "NO";
            }
            con.Open();
            string quary = "select * from CarTb1 where Available = '"+flag+"'";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void AvailableCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
