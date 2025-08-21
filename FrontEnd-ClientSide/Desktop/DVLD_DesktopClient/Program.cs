using DVLD_DesktopClient.Applications.Local_Driving_License;
using DVLD_DesktopClient.FormTesting;
using DVLD_DesktopClient.Login;

namespace DVLD_DesktopClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
           Application.Run(new frmLogin());
           //Application.Run(new frmLocalDrivingLicenseApplicationInfo(1050));

        }
    }
}