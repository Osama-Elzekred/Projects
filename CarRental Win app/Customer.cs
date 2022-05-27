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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        public void disp()
        {
            con.Open();
            string quary = "select * from CustomerTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CustomerTb1 values ('" + IdTb.Text + "','" + NameTb.Text + "','" + AddressTb.Text + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                    //string query = $"delete from CustomerTb1 where Custid= {IdTb.Text} "; //SQL Injection 
                    string query = "delete from CustomerTb1 where Custid= @Id ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.Parameters.Add("@Id", SqlDbType.Int);
                    //cmd.Parameters["@Id"].Value = int.Parse(IdTb.Text);
                    // or
                    cmd.Parameters.AddWithValue("@Id", int.Parse(IdTb.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CustomerTb1 set CustName='" + NameTb.Text + "',CustAdd='" + AddressTb.Text + "',Phone='" + PhoneTb.Text + "' where Custid='" + IdTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
