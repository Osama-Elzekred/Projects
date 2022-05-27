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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }

        private void Rental_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carRentalDataSet.UserTb1' table. You can move, or remove it, as needed.
            this.userTb1TableAdapter.Fill(this.carRentalDataSet.UserTb1);
            fillcombo();
            fillCustomer();
            disp();
        }
        SqlDataAdapter da;
        DataSet ds;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        private void fillcombo()
        {
            con.Open();

            // by me

            //string quary2 = "select * from CarTb1 where Available = '" + "YES" + "'";
            //da = new SqlDataAdapter(quary2, con);
            //ds = new DataSet();
            //da.Fill(ds, "CarTb1");
            //CustCb.DataSource = ds.Tables["CarTb1"];
            //CustCb.ValueMember = "RegNum";
            //CarRegCb.DisplayMember = "Model";



            string quary = "select  Brand+' '+Model as CarName ,RegNum  from CarTb1 where Available = '" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(quary, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CarName", typeof(string));
            dt.Columns.Add("RegNum", typeof(string));

            dt.Load(rdr);
            CarRegCb.DisplayMember = "CarName";
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            con.Close();
        }
        private void fillCustomer()
        {
            con.Open();
            

            // by me 
            string quary2 = "select * from CustomerTb1";
            da = new SqlDataAdapter(quary2, con);
            ds = new DataSet();
            da.Fill(ds, "CustomerTb1");
            CustCb.DataSource = ds.Tables["CustomerTb1"];
            CustCb.DisplayMember = "Custid";
            CustCb.ValueMember = "Custid";
            //carId = 

            //string quary = "select Custid from CustomerTb1";
            //SqlCommand cmd = new SqlCommand(quary, con);
            //SqlDataReader rdr;
            //rdr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Custid", typeof(int));
            //dt.Load(rdr);
            //CustCb.ValueMember = "Custid";
            //CustCb.DataSource = dt;
            con.Close();
        }
        private void fetchCustName()
        {
            con.Open();
            string quary = "select * from CustomerTb1 where Custid='"+CustCb.SelectedValue.ToString()+"'";
            SqlCommand cmd = new SqlCommand(quary,con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            con.Close();
        }
        private void UpdateOnRent()
        {
            con.Open();
            //string tem
            string query = "update CarTb1 set Available='"+"NO"+"' where RegNum=" + CarRegCb.SelectedValue.ToString() ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateOnRentDelete()
        {
            con.Open();
            string query = "update CarTb1 set Available='" + "YES" + "' where RegNum='" + carId.Text.ToString()+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
        public void disp()
        {
            con.Open();
            string quary = "select * from RentalTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

     
        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FeesTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into RentalTb1 values ('" + IdTb.Text + "','" + CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + RentDate.Text + "','" + ReturnDate.Text + "','" + FeesTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Added Successfully");
                    con.Close();
                    UpdateOnRent();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
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
                    string query = "delete from RentalTb1 where RentId='" + IdTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Deleted Successfully");
                    con.Close();
                    disp();
                    UpdateOnRentDelete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RentDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            // MessageBox.Show(RentDGV.SelectedRows[0].Cells[1].Value.ToString());
            //CarRegCb.SelectedValue = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            carId.Text = RentDGV.SelectedRows[0].Cells[1].Value.ToString();

            //CustNameTb.Text = RentDGV.SelectedRows[0].Cells[3].Value.ToString();
            FeesTb.Text = RentDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            carId.Text = CarRegCb.SelectedValue.ToString();
        }
    }
}
