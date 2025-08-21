using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopClient.GlobalClasses
{
    internal class clsUtility
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }


        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            // the folder path should not be hard coded need to be choosed by user in its divice
            string DestinationFolder = @"S:\14    PFE_DVLD\TheProjectDVLDVersion2.0.0\FrontEnd-ClientSide\Desktop\DVLD_DesktopClient\Resources\DVLD_People_Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static string DateToShortFormat(DateTime Dt1)
        {

            return Dt1.ToString("dd/MMM/yyyy");
        }
        #region make the form radius
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(

        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );
        public static void BorderFormRadius(Form ftm, int x, int y)
        {
            ftm.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ftm.Width, ftm.Height, 50, 50));
        }
        public  static void RoundPanelCorners(Panel panel, int radius)
        {
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, radius, radius));
        }
        #endregion
    }
}
