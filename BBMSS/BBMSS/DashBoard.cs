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
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();


            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();



            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTbl", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            EmployeeLbl.Text = dt2.Rows[0][0].ToString();



            SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from BloodTbl", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text = "" + BStock;




            SqlDataAdapter sda4 = new SqlDataAdapter("Select count(*) from BloodTbl where BGroup='"+"O+"+"'", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OplusNumLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);


            //AB+


            SqlDataAdapter sda5 = new SqlDataAdapter("Select count(*) from BloodTbl where BGroup='" + "AB+" + "'", con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            OplusNumLbl.Text = dt5.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);


            con.Close();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
