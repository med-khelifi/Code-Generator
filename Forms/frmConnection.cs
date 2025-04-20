using CodeGenerator_Project.Connection;
using CodeGenerator_Project.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator_Project
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServer.Focus();
            pbConnecting.Visible = false;

            string userId = "", password = "", server = "";
            if(clsUtil.GetStoredCredential(ref server,ref userId,ref password))
            {
                txtPassword.Text = password;
                txtServer.Text = server;
                txtUserID.Text = userId;    

                chkRememberMe.Checked = true;
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtUserID.Text)) 
            {
                MessageBox.Show("Fill All Field To Connect.",
                                "Empty Field",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            pbConnecting.Visible = true;
            btnConnect.Visible = false;

            bool isConnected = await clsConnection.Connect(txtServer.Text.Trim(), txtUserID.Text.Trim(), txtPassword.Text.Trim());

            if (isConnected)
            {
                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsUtil.RememberUsernameAndPassword(txtServer.Text.Trim(), txtUserID.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsUtil.RememberUsernameAndPassword("", "", "");

                }

                pbConnecting.Visible = false;
                btnConnect.Visible = true;


                frmMain frm = new frmMain();
                //this.Hide(); // Hide current form
                frm.Show();
            }
            else
            {
                pbConnecting.Visible = false;
                btnConnect.Visible = true;

                MessageBox.Show("Error: Cannot connect to server. Please check your credentials and try again.",
                                "Connection Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

    }
}
