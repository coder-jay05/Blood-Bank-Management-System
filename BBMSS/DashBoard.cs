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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GetData();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C1CC6L4T\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True");
        private void GetData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl", con);           //donor update
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();


             SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", con);                //transfer update
             DataTable dt1 = new DataTable();
             sda1.Fill(dt1);
             TransferLbl.Text = dt1.Rows[0][0].ToString();

             



              SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTbl", con);           //employee update
              DataTable dt2 = new DataTable();
              sda2.Fill(dt2);
              EmployeeLbl.Text = dt2.Rows[0][0].ToString();

             



              SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from BloodTbl", con);          // blood stock all
              DataTable dt3 = new DataTable();
              sda3.Fill(dt3);
              int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
              TotalLbl.Text = "" + BStock;



            SqlDataAdapter sda4 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='"+"O+"+"'", con);           //O+ unit  update
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OplusNumLbl.Text = dt4.Rows[0][0].ToString();

            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;       //progress bar
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);


           // con.Close();


              //AB+


              SqlDataAdapter sda5 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='"+"AB+"+"'", con);
              DataTable dt5 = new DataTable();
              sda5.Fill(dt5);
              ABplusNumLbl.Text = dt5.Rows[0][0].ToString();                                   //unit blood run

            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;       //progress bar run
            ABPlusProgress.Value = Convert.ToInt32(ABplusPercentage);


           // con.Close();



            //O-

             SqlDataAdapter sda6 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='"+"O-"+"'", con);
             DataTable dt6 = new DataTable();
             sda6.Fill(dt6);
             OminusNumLbl.Text = dt6.Rows[0][0].ToString();


             double OminusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
             OminusProgress.Value = Convert.ToInt32(OminusPercentage);

           //  con.Close();


             //AB-

             SqlDataAdapter sda7 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='"+"AB-"+"'", con);
             DataTable dt7 = new DataTable();
             sda7.Fill(dt7);
             ABminusLbl.Text = dt7.Rows[0][0].ToString();

             double ABminusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
             ABminusProgress.Value = Convert.ToInt32(ABminusPercentage);


            //B+

            SqlDataAdapter sda8 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "B+" + "'", con);
            DataTable dt8 = new DataTable();
            sda7.Fill(dt8);
            BplusNumLbl.Text = dt8.Rows[0][0].ToString();

            double BplusPercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / BStock) * 100;
            BPlusProgress.Value = Convert.ToInt32(BplusPercentage);


            //B-

            SqlDataAdapter sda9 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "B-" + "'", con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            BminusLbl.Text = dt9.Rows[0][0].ToString();

            double BminusPercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / BStock) * 100;
            BminusProgress.Value = Convert.ToInt32(BminusPercentage);


            //A+

            SqlDataAdapter sda10 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "A+" + "'", con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            AplusLbl.Text = dt10.Rows[0][0].ToString();

            double AplusPercentage = (Convert.ToDouble(dt10.Rows[0][0].ToString()) / BStock) * 100;
            AplusProgress.Value = Convert.ToInt32(AplusPercentage);


            //A-


            SqlDataAdapter sda11 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "A-" + "'", con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            AminusNumLbl.Text = dt11.Rows[0][0].ToString();

            double AminusPercentage = (Convert.ToDouble(dt11.Rows[0][0].ToString()) / BStock) * 100;
            AminusProgress.Value = Convert.ToInt32(AminusPercentage);






            con.Close();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor Ob = new ViewDonor();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Ob = new Patient();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewPatients Ob = new ViewPatients();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock Ob = new BloodStock();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodTransfert Ob = new BloodTransfert();
            Ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void TotalLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
