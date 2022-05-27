using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rental = new Rental();
            rental.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new Users();
            users.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return ret = new Return();
            ret.Show();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
