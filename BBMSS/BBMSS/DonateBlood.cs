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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BBMSS
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C1CC6L4T\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True");
        private void populate()
        {
            con.Open();
            string query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            con.Close();
        }

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

        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            con.Open();
            string query = "select * from bloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            con.Close();
        }

        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text = DonorDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void DonorDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            DNameTb.Text = DonorDGV.Rows[RowIndex].Cells[1].Value.ToString();
            BGroupTb.Text = DonorDGV.Rows[RowIndex].Cells[6].Value.ToString();
            GetStock(BGroupTb.Text);
        }
        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1;
                    string query = "update BloodTbl set BStock=" + stock + " where BGroup='" + BGroupTb.Text + "';";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successful");
                    con.Close();
                    reset();
                    bloodStock();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
