using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Users.Controles
{
    public partial class ctrlUserCard : UserControl
    {
        private clsDTOs.clsUserDTO _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {

            cntPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[...]";
            lblUserName.Text = "[...]";
            lblIsActive.Text = "[...]";
        }
        private void _FillUserInfo()
        {

            cntPersonCard1.LoadPersonInfo(_User.personID);
            lblUserID.Text = _User.userID.ToString();
            lblUserName.Text = _User.userName.ToString();

            if (_User.isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }
        public async void LoadUserInfo(int UserID)
        {
            //_User = clsUser.FindByUserID(UserID);
            _User = await clsUsersAsync.GetUserInfoByUserIDAsync(UserID);

            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }


    }
}
