using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Research.Kinect.Nui;

namespace Ryerson.KinectGallery
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MouseWindow : Window
    {
        #region fields

        Runtime runtime = new Runtime();

        private const int EVENT_TIME = 250;
        private DispatcherTimer _timer = new DispatcherTimer();
        private String _lastControlTouched = "";

        #endregion fields

        #region constructors

        /// <summary>
        /// 
        /// </summary>
        public MouseWindow()
        {
            InitializeComponent();

            // listen for keyboard events
            this.KeyUp += new KeyEventHandler(MouseWindow_KeyUp);

            // start interaction timer
            _timer.Interval = new TimeSpan(0, 0, 0, 0, EVENT_TIME);
            _timer.Tick += new EventHandler(_timer_Tick);

            // initialize kinect
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Unloaded += new RoutedEventHandler(MainWindow_Unloaded);

            // handle data from kinect
            runtime.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(runtime_VideoFrameReady);
            runtime.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(runtime_SkeletonFrameReady);
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            // if nui idle time > max_idle_cursor_threshold, return to normal cursor
            // if nui idle time > max_idle_display, fade the nui display to transparent
            // if nui idle time > max_idle_time, revert to default display focus
            Console.WriteLine("Control " + _lastControlTouched + " selected");
            _timer.Stop();

            // change cursor
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.Source is Border)
            {
                // change background
                Border b = (Border)e.Source;
                Color c = Color.FromArgb(100, 255, 255, 255);
                SolidColorBrush scb = new SolidColorBrush(c);
                b.Background = scb;

                // change cursor
                this.Cursor = Cursors.Wait;

                // start timer
                _lastControlTouched = b.Name;
                _timer.Start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.Source is Border)
            {
                Border b = (Border)e.Source;
                SolidColorBrush scb = Brushes.Transparent;
                b.Background = scb;
                _timer.Stop();
                // change cursor
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.U:
                    // up arrow key
                    break;
                case Key.J:
                    // right arrow key
                    break;
                case Key.H:
                    // down arrow key
                    break;
                case Key.N:
                    // left arrow key
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Since only a color video stream is needed, RuntimeOptions.UseColor is used.
            runtime.Initialize(Microsoft.Research.Kinect.Nui.RuntimeOptions.UseColor | RuntimeOptions.UseSkeletalTracking);
            //You can adjust the resolution here.
            runtime.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            runtime.Uninitialize();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runtime_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {

            SkeletonFrame skeletonSet = e.SkeletonFrame;

            SkeletonData data = (from s in skeletonSet.Skeletons
                                 where s.TrackingState == SkeletonTrackingState.Tracked
                                 select s).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runtime_VideoFrameReady(object sender, Microsoft.Research.Kinect.Nui.ImageFrameReadyEventArgs e)
        {
            PlanarImage image = e.ImageFrame.Image;
            BitmapSource source = BitmapSource.Create(image.Width, image.Height, 96, 96,
                PixelFormats.Bgr32, null, image.Bits, image.Width * image.BytesPerPixel);
            videoImage.Source = source;
        }

        #endregion methods

    }
}
