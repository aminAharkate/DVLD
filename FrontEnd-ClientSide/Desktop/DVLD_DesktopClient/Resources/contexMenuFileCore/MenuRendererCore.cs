using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Resources.ContexMenuFile
{
    public class MenuRendererCore : ToolStripProfessionalRenderer
    {
        // Fields
        private readonly Color _primaryColor;
        private readonly Color _textColor;
        private readonly int _arrowThickness;
        private static readonly Size ArrowSize = new(5, 12); // Made static readonly for better performance

        // Constructor
        public MenuRendererCore(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            _primaryColor = primaryColor;
            _arrowThickness = isMainMenu ? 3 : 2; // Ternary operator for cleaner initialization

            // Set text color with null-coalescing for Color.Empty case
            _textColor = textColor == Color.Empty
                ? isMainMenu ? Color.Gainsboro : Color.DimGray
                : textColor;
        }

        // Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Item.ForeColor = e.Item.Selected ? Color.White : _textColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Cache frequently used objects
            var graphics = e.Graphics;
            var arrowColor = e.Item.Selected ? Color.White : _primaryColor;

            // Calculate arrow position (vertically centered)
            var rect = new Rectangle(
                e.ArrowRectangle.Location.X,
                e.ArrowRectangle.Top + (e.ArrowRectangle.Height - ArrowSize.Height) / 2,
                ArrowSize.Width,
                ArrowSize.Height);

            // Using declarations for automatic disposal
            using var path = new GraphicsPath();
            using var pen = new Pen(arrowColor, _arrowThickness)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw arrow lines
            path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
            path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);

            graphics.DrawPath(pen, path);
        }
    }
}