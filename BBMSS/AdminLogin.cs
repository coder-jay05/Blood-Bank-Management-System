﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMSS
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter The Admin Password");
            }
            else if(AdminPassTb.Text == "password")
            {
                Employee Emp = new Employee();
                Emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password.Contact the system Admin");
                AdminPassTb.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void AdminPassTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
