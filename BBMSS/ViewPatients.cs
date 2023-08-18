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

namespace BBMSS
{
    public partial class ViewPatients : Form
    {
        public ViewPatients()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C1CC6L4T\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True");

        private void populate()
        {
            con.Open();
            string query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)    // NO USE 
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[0].Value.ToString();
            PAgeTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PphoneTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PGenCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PBGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PAddressTb.Text = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
        }
        int key = 0;
        private void PatientsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;

            PNameTb.Text = PatientsDGV.Rows[RowIndex].Cells[1].Value.ToString();
            PAgeTb.Text = PatientsDGV.Rows[RowIndex].Cells[2].Value.ToString();
            PphoneTb.Text = PatientsDGV.Rows[RowIndex].Cells[3].Value.ToString();
            PGenCb.Text= PatientsDGV.Rows[RowIndex].Cells[4].Value.ToString();
            PBGroupCb.Text = PatientsDGV.Rows[RowIndex].Cells[5].Value.ToString();
            PAddressTb.Text = PatientsDGV.Rows[RowIndex].Cells[6].Value.ToString();

            if(PNameTb.Text == "")
            {
                key = 1;
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PphoneTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
            key = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(key == 1)
            {
                MessageBox.Show("select the patient to delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTbl where PNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
                    con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAgeTb.Text == "" || PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAddressTb.Text == "")
            {
                MessageBox.Show("Missimg information");
            }
            else
            {
                try
                {
                    string query = "update PatientTbl set Pname='" + PNameTb.Text + "',Page=" + PAgeTb.Text + ",Pphone='" + PphoneTb.Text + "',PGender='" + PGenCb.SelectedItem.ToString()+"',PBGroup='"+PBGroupCb.SelectedItem.ToString()+"',Padrress='"+PAddressTb.Text+"' where PNum="+key+";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully updated");
                    con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
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
    }
}
