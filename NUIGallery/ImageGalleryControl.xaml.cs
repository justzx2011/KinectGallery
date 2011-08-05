using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Collections.Generic;

namespace Ryerson.NUIGallery
{
    /// <summary>
    /// Cycles through the display of a collection of images in a folder.  If a metadata
    /// file exists in the folder, it will display images in the sequence denoted in the
    /// file.
    /// </summary>
    public partial class ImageGalleryControl : UserControl
    {
        #region fields

        // image formats
        private const String BMP = "bmp";
        private const String GIF = "gif";
        private const String JPG = "jpg";
        private const String PNG = "png";
        private const String TIF = "tif";

        // animation settings
        private const int OPAQUE = 1;           // opaque
        private const int TRANSPARENT = 0;      // transparent
        private const int FADE_OUT_TIME = 10;   // milliseconds
        private const int FADE_IN_TIME = 10;    // milliseconds
        private const int INTERVAL = 300;       // update period

        private TimeSpan _timerInterval = new TimeSpan(0, 0, 0, 0, INTERVAL);
        private DispatcherTimer _timer = new DispatcherTimer();
        private DoubleAnimation _fade_out = new DoubleAnimation();
        private DoubleAnimation _fade_in = new DoubleAnimation();

        // image collection
        private string _path = "";
        private List<FileInfo> _files = new List<FileInfo>(); // file collection
        private int _cursor = 0; // current position in collection

        // metadata file
        private bool METADATA_EXISTS = false;   // true if the file exists in the current context
        private FileInfo metadataFile = null;

        // display layout mode
        public enum LAYOUT_MODE { SINGLE_IMAGE, GRID, DETAIL_CONTEXT };
        private LAYOUT_MODE layout_mode = LAYOUT_MODE.SINGLE_IMAGE;

        #endregion fields
        #region properties

        /// <summary>
        /// Get and set the image gallery layout mode.
        /// </summary>
        public LAYOUT_MODE LayoutMode
        {
            get
            {
                return layout_mode;
            }
            set
            {
                layout_mode = value;
                LayoutModeChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Get and set path to folder with images.
        /// </summary>
        public String Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                PathChanged(this, new EventArgs());
            }
        }

        #endregion properties
        #region events

        /// <summary>
        /// Layout mode changed
        /// </summary>
        public event EventHandler LayoutModeChanged;

        /// <summary>
        /// Path changed
        /// </summary>
        public event EventHandler PathChanged;

        #endregion events
        #region constructors

        /// <summary>
        /// ImageGalleryControl constructor
        /// </summary>
        public ImageGalleryControl()
        {
            InitializeComponent();
            // configure timer
            _timer.Interval = _timerInterval;
            _timer.IsEnabled = true;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Stop();
        }

        #endregion constructors
        #region methods

        /// <summary>
        /// Handle timer tick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Start updating.
        /// </summary>
        public void Start()
        {
            if (_timer != null) _timer.Start();
        }

        /// <summary>
        /// Stop updating.
        /// </summary>
        public void Stop()
        {
            if (_timer != null) _timer.Stop();
        }

        /// <summary>
        /// Generate the display.
        /// </summary>
        private void UpdateDisplay()
        {
            // if the directory exists
            DirectoryInfo dir = new DirectoryInfo(_path);
            if (dir.Exists)
            {
                // get the list of image files
                List<FileInfo> images = new List<FileInfo>();
                FileInfo[] files = dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i];
                    if (file.Extension.Equals(BMP) ||
                        file.Extension.Equals(GIF) ||
                        file.Extension.Equals(JPG) ||
                        file.Extension.Equals(PNG) ||
                        file.Extension.Equals(TIF))
                    {
                        images.Add(file);
                    }
                }
                // 
            }
        }

        /// <summary>
        /// UserControl loaded event handler. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// UserControl size changed event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateDisplay();
        }

        #endregion methods

    }
}
