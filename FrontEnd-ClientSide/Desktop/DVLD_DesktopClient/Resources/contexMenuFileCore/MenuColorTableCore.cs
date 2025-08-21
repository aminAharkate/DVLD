//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DVLD_DesktopClient.Resources.ContexMenuFile.contexMenuFileCore
//{
//    internal class Class1
//    {
//    }
//}
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Resources.contexMenuFileCore
{
    public class MenuColorTableCore : ProfessionalColorTable
    {
        // Fields
        private readonly Color _backColor;
        private readonly Color _leftColumnColor;
        private readonly Color _borderColor;
        private readonly Color _menuItemBorderColor;
        private readonly Color _menuItemSelectedColor;

        // Constructor
        public MenuColorTableCore(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                // Dark theme colors
                _backColor = Color.FromArgb(37, 39, 60);
                _leftColumnColor = Color.FromArgb(32, 33, 51);
                _borderColor = Color.FromArgb(32, 33, 51);
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
            else
            {
                // Light theme colors
                _backColor = Color.White;
                _leftColumnColor = Color.LightGray;
                _borderColor = Color.LightGray;
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
        }

        // Overrides
        public override Color ToolStripDropDownBackground => _backColor;
        public override Color MenuBorder => _borderColor;
        public override Color MenuItemBorder => _menuItemBorderColor;
        public override Color MenuItemSelected => _menuItemSelectedColor;
        public override Color ImageMarginGradientBegin => _leftColumnColor;
        public override Color ImageMarginGradientMiddle => _leftColumnColor;
        public override Color ImageMarginGradientEnd => _leftColumnColor;
    }
}
