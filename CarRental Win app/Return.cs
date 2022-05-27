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
    public partial class Return : Form
    {
        DataSet ds;
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        private void Return_Load(object sender, EventArgs e)
        {
            disp();
            dispRetun();
        }
        public void disp()
        {
            con.Open();
            string quary = "select * from RentalTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
             ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
           
            con.Close();
        }
        private void dispRetun()
        {
            con.Open();
            string quary = "select * from ReturnTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarIdTb.Text = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int nrOfDayes = Convert.ToInt32(t.TotalDays);
            if (nrOfDayes <= 0)
            {
                DelayTb.Text = "No Delay";
                FineTb.Text = "0";
            }
            else
            {
                DelayTb.Text = "" + nrOfDayes;
                FineTb.Text = "" + (nrOfDayes * 250);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
        private void DeleteOnReturn()
        {
            int rentId;
            rentId=Convert.ToInt32( RentDGV.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            string query = "delete from RentalTb1 where RentId=" + rentId + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Rent Deleted Successfully");
            con.Close();
            disp();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FineTb.Text == "" || DelayTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into ReturnTb1 values ('" + IdTb.Text + "','" + CarIdTb.Text+ "','" + CustNameTb.Text + "','" + ReturnDate.Text + "','" + DelayTb.Text + "','" + FineTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Returned Successfully");
                    con.Close();
                    //UpdateOnRent();
                    //disp();
                    dispRetun();
                    DeleteOnReturn();
                    UpdateOnRentDelete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void UpdateOnRentDelete()
        {
            con.Open();
            string query = "update CarTb1 set Available='" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = $"delete from ReturnTb1 where ReturnId='{ IdTb.Text }'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Returned Rent Deleted Successfully");
                    ReturnDGV.DataSource = ds.Tables[0];
                    con.Close();
                    dispRetun();
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
