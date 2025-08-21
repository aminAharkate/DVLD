using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LApplicationID = -1;
        public frmLocalDrivingLicenseApplicationInfo(int LApplicationID)
        {
            InitializeComponent();
            _LApplicationID = LApplicationID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async  void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
             await ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LApplicationID);
            //try
            //{
            //    loadingSpinner.Visible = true;
            //    await ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppIDAsync(_LApplicationID);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading application: {ex.Message}", "Error",
            //                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    loadingSpinner.Visible = false;
            //}
        }
    }
}
