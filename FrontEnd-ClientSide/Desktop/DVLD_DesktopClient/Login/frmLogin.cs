using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Login
{
    public partial class frmLogin : Form
    {
        #region radius border
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(

        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );
        #endregion
        public frmLogin()
        {
            InitializeComponent();
            #region radius border
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            #endregion
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            clsDTOs.clsUserDTO user = await clsUsersAsync.GetUserInfoByUsernameAndPasswordAsync(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobalUser.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobalUser.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                if (!user.isActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobalUser.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btncloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobalUser.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        //***************************************************************************




    }
}
