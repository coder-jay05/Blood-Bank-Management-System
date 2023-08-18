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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BBMSS
{
    public partial class BloodTransfert : Form
    {
        public BloodTransfert()
        {
            InitializeComponent();
            fillPatientCb();
            transact();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C1CC6L4T\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True");
        
        private void transact()
        {
            
            string query = "select * from TransferTbl";
            SqlDataAdapter trs = new SqlDataAdapter(query, con);
            SqlCommandBuilder build = new SqlCommandBuilder();
            var ds = new DataSet();
            trs.Fill(ds);
            BloodHistory.DataSource = ds.Tables[0];
            
        }





        private void fillPatientCb()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PName", typeof(string));
            dt.Load(rdr);
            PatientidCb.ValueMember = "PNum";
            PatientidCb.DataSource = dt;
            con.Close();
        }

        private void GetData()
        {
            con.Open();
            string query = "select * from PatientTbl where PNum=" + PatientidCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PName"].ToString();
                BloodGroup.Text = dr["PBGroup"].ToString();
            }
            con.Close();
        }

        int stock=0;
        private void GetStock(string Bgroup)
        {
            con.Open();
            string query = "select * from bloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());
            }
            con.Close();
        }


        private void BloodTransfert_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

      /*  int oldstock;
        private void GetStock(string Bgroup)
        {
            con.Open();
            string query = "select * from bloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            con.Close();
        }*/

        private void PatientidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodGroup.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Available STock";
                AvailableLbl.Visible = true;
            }
            else
            {
                AvailableLbl.Text = "Stock not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void Reset()
        {
            PatNameTb.Text = "";
            //PatientidCb.SelectedIndex = -1;
            BloodGroup.Text = "";
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        private void updatestock()
        {
            int newstock = stock -1;
            try
            {
                string query = "update BloodTbl set BStock=" + newstock + " where BGroup='" + BloodGroup.Text + "';";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Patient Successfully updated");
                con.Close();
                
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
        

                ///

                if (PatNameTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + PatNameTb.Text + "','" + BloodGroup.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Transfer");
                    con.Close();
                    GetStock(BloodGroup.Text);
                    updatestock();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock Bstock = new BloodStock();
            Bstock.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            ViewPatients Ob = new ViewPatients();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
          


        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (PatientidCb.Text == "" || PatNameTb.Text == "" || BloodGroup.Text == "")
            {
                MessageBox.Show("missing");
            }
            else
            {
                try
                {
                    string query = " insert into PtranhistoryTbl values('" + PatientidCb.SelectedItem.ToString() + "','" + PatNameTb.Text + "','" + BloodGroup.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("success");
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }



        }

        private void BloodHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            transact();
            timer1.Start();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(BloodHistory.Width, BloodHistory.Height);
            BloodHistory.DrawToBitmap(imagebmp, new Rectangle(0, 0, BloodHistory.Width, BloodHistory.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
