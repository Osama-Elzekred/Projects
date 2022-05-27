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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            con.Open();
            string quary = "select count (*) from UserTb1 where Uname ='" + Uname.Text + "' and Upass = '" + Upass.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(quary,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //MessageBox.Show($"{dt.Rows[0][0].ToString()} ");
            if (dt.Rows[0][0].ToString()=="1")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Uname.Clear();
            Upass.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
