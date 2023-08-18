using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMSS
{
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            bloodStock();
        }


        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C1CC6L4T\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True");
       

        private void bloodStock()
        {
            con.Open();
            string query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void BloodStock_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodTransfert Bt = new BloodTransfert();
            Bt.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donate = new Donor();
            donate.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonateBlood donate = new DonateBlood();
            donate.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor donate = new ViewDonor();
            donate.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient donate = new Patient();
            donate.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewPatients donate = new ViewPatients();
            donate.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock donate = new BloodStock();
            donate.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard donate = new DashBoard();
            donate.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void printepage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.BloodStockDGV.Width, this.BloodStockDGV.Height);
            BloodStockDGV.DrawToBitmap(bm, new Rectangle(0,0,this.BloodStockDGV.Width,this.BloodStockDGV.Height));
            e.Graphics.DrawImage(bm,0,0);
        }

        private void printA_Click(object sender, EventArgs e)
        {
            
        }
    }
}
