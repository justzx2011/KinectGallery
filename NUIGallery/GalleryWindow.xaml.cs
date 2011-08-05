using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Win32_API;

namespace Ryerson.NUIGallery
{
    /// <summary>
    /// Interaction logic for GalleryWindow.xaml
    /// </summary>
    public partial class GalleryWindow : Window
    {
        #region fields

        private const int OPAQUE = 1;
        private const int TRANSPARENT = 0;
        private const int FADE_OUT_TIME = 1;        // milliseconds
        private const int FADE_IN_TIME = 1;         // milliseconds
        private const int MAX_IDLE_TIME = 6000;     // milliseconds
        private const int IDLE_TIME_CHECK = 1000;   // milliseconds

        private DoubleAnimation _fade_out;
        private DoubleAnimation _fade_in;

        private DispatcherTimer _idletimer = new DispatcherTimer();
        
        private UIElement _currentui;
        private ImageGalleryControl _imageGallery = new ImageGalleryControl();
        private VideoGalleryControl _videoGallery = new VideoGalleryControl();
        private BrowserControl _webbrowser = new BrowserControl();

        #endregion fields
        #region properties

        /// <summary>
        /// Idle time in milliseconds.
        /// </summary>
        public long IdleTime
        {
            get
            {
                return Win32_API.Win32.GetIdleTime();
            }
        }
        
        #endregion properties
        #region constructors

        /// <summary>
        /// MainWindow constructor.
        /// </summary>
        public GalleryWindow()
        {
            InitializeComponent();
            // current display
            _currentui = null; // default display
            // animations
            SetupDefaultAnimations();
            // event listeners
            App app = (App) Application.Current;
            app.PathChanged += new EventHandler(Handle_App_PathChanged);
            xMenu.NavigateUp += new EventHandler(xMainMenu_NavigateUp);
            // idle time monitor
            _idletimer.Interval = new TimeSpan(0,0,0,0,IDLE_TIME_CHECK);
            _idletimer.Tick += new EventHandler(CheckIdleTime);
        }

        #endregion constructors
        #region methods

        /// <summary>
        /// Check idle time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckIdleTime(object sender, EventArgs e)
        {
            uint idletime = Win32.GetIdleTime();
            if (idletime > MAX_IDLE_TIME)
            {
                Console.WriteLine("MAX_IDLE_TIME exceeded");
            }
        }

        /// <summary>
        /// Crossfade UI elements.
        /// </summary>
        /// <param name="Element">UIElement to crossfade to</param>
        private void CrossfadeToUIElement(UIElement Element)
        {
            CrossfadeUIElements(_currentui, Element);
        }

        /// <summary>
        /// Cross fade 
        /// </summary>
        /// <param name="Element1">Current UI Element</param>
        /// <param name="Element2">UI Element to crossfade to</param>
        private void CrossfadeUIElements(UIElement Element1, UIElement Element2)
        {
            // fade out the current element
            if (Element1 != null)
            {
                Element1.BeginAnimation(UserControl.OpacityProperty, _fade_out);
            }
            // fade in the new element
            if (Element2 != null)
            {
                Element2.Opacity = 0;
                Element2.Visibility = System.Windows.Visibility.Visible;
                Element2.BeginAnimation(UserControl.OpacityProperty, _fade_in);
            }
        }

        /// <summary>
        /// Handle path changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_App_PathChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuControl_MenuClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Menu button clicked somewhere");
            UpdateDisplay();
            // determine which control sent the command
            // switch view based on the sender
        }

        /// <summary>
        /// Configure default animations.
        /// </summary>
        private void SetupDefaultAnimations()
        {
            _fade_out = new DoubleAnimation();
            _fade_out.From = OPAQUE;
            _fade_out.To = TRANSPARENT;
            _fade_out.Duration = new TimeSpan(0, 0, 0, 0, FADE_OUT_TIME);

            _fade_in = new DoubleAnimation();
            _fade_in.From = TRANSPARENT;
            _fade_in.To = OPAQUE;
            _fade_in.Duration = new TimeSpan(0, 0, 0, 0, FADE_IN_TIME);
        }

        /// <summary>
        /// Update the window display.
        /// </summary>
        private void UpdateDisplay()
        {
            if (_currentui == xMenu)
            {
                _currentui = xImageGallery;
                CrossfadeUIElements(xMenu, xImageGallery);
            }
            else if (_currentui == xImageGallery)
            {
                _currentui = xVideoGallery;
            }
            else if (_currentui == xVideoGallery)
            {
                _currentui = null;
            }
            else if (_currentui == null)
            {
                _currentui = xMenu;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _currentui = xMenu;
            CrossfadeToUIElement(xMenu);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void xMainMenu_NavigateUp(object sender, EventArgs e)
        {
            CrossfadeToUIElement(null);
        }

        #endregion methods

    }
}
