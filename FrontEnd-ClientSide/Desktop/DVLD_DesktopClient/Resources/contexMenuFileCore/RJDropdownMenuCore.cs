using DVLD_DesktopClient.Resources.ContexMenuFile;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Resources.ContexMenuFile
{
    [DesignerCategory("Code")] // Better designer integration
    public class RJDropdownMenuCore : ContextMenuStrip
    {
        // Constants
        private const int DefaultMenuItemHeight = 25;
        private const int MainMenuHeaderHeight = 45;
        private const int MainMenuHeaderWidth = 25;
        private const int SubMenuHeaderWidth = 20;

        // Fields with default values
        private bool _isMainMenu;
        private int _menuItemHeight = DefaultMenuItemHeight;
        private Color _menuItemTextColor = Color.Empty;
        private Color _primaryColor = Color.Empty;
        private Bitmap? _menuItemHeaderSize;

        // Constructors
        public RJDropdownMenuCore() => InitializeDefaults();

        public RJDropdownMenuCore(IContainer container) : base(container)
            => InitializeDefaults();

        // Properties with better encapsulation
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMainMenu
        {
            get => _isMainMenu;
            set
            {
                if (_isMainMenu != value)
                {
                    _isMainMenu = value;
                    UpdateRenderer();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MenuItemHeight
        {
            get => _menuItemHeight;
            set
            {
                if (_menuItemHeight != value && value > 0)
                {
                    _menuItemHeight = value;
                    LoadMenuItemHeight();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color MenuItemTextColor
        {
            get => _menuItemTextColor;
            set
            {
                if (_menuItemTextColor != value)
                {
                    _menuItemTextColor = value;
                    UpdateRenderer();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PrimaryColor
        {
            get => _primaryColor;
            set
            {
                if (_primaryColor != value)
                {
                    _primaryColor = value;
                    UpdateRenderer();
                }
            }
        }

        // Initialization
        private void InitializeDefaults()
        {
            RenderMode = ToolStripRenderMode.Professional;
            ShowImageMargin = true;
        }

        // Menu item height management
        // Updated LoadMenuItemHeight
        private void LoadMenuItemHeight()
        {
            _menuItemHeaderSize?.Dispose();

            try
            {
                _menuItemHeaderSize = IsMainMenu
                    ? new Bitmap(MainMenuHeaderWidth, MainMenuHeaderHeight)
                    : new Bitmap(SubMenuHeaderWidth, _menuItemHeight);
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine($"Error creating menu bitmap: {ex.Message}");
                _menuItemHeaderSize = new Bitmap(1, 1); // Fallback
            }
        }

        // Recursive method with modernized implementation
        // Updated ApplyHeaderSizeToItems method
        private void ApplyHeaderSizeToItems(ToolStripItemCollection items)
        {
            if (_menuItemHeaderSize == null) return; // Safety check

            foreach (var item in items.OfType<ToolStripMenuItem>())
            {
                try
                {
                    item.ImageScaling = ToolStripItemImageScaling.None;

                    // Only assign if the image is null AND we have a valid bitmap
                    if (item.Image == null && _menuItemHeaderSize != null)
                    {
                        // Create a new copy of the bitmap to avoid disposal issues
                        item.Image = new Bitmap(_menuItemHeaderSize);
                    }

                    if (item.HasDropDownItems)
                    {
                        ApplyHeaderSizeToItems(item.DropDownItems);
                    }
                }
                catch (ArgumentException ex)
                {
                    // Log or debug this if needed
                    Debug.WriteLine($"Error assigning image to menu item: {ex.Message}");
                    continue;
                }
            }
        }

        // Renderer management
        // Updated UpdateRenderer method
        private void UpdateRenderer()
        {
            if (!DesignMode && !IsDisposed)
            {
                // Initialize the bitmap first
                LoadMenuItemHeight();

                // Then create the renderer
                Renderer = new MenuRenderer(_isMainMenu, _primaryColor, _menuItemTextColor);
            }
        }


        // Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                UpdateRenderer();
            }
        }

        // Cleanup
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _menuItemHeaderSize?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}









