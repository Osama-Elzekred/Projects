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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void disp()
        {
            con.Open();
            string quary = "select * from UserTb1";
            SqlDataAdapter da = new SqlDataAdapter(quary,con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Users_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into UserTb1 values ('" + Uid.Text + "','" + Uname.Text + "','" + Upass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Users Added Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from UserTb1 where Id='"+Uid.Text+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Users Deleted Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update UserTb1 set Uname='"+Uname.Text+"',Upass='"+Upass.Text+"' where Id='" + Uid.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Users Updated Successfully");
                    con.Close();
                    disp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Uid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Upass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
