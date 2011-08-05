using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Ryerson.NUIGallery
{
    /// <summary>
    /// Interaction logic for AnimatedCursor.xaml
    /// </summary>
    public partial class AnimatedCursor : UserControl
    {
        #region fields

        private const int MIN_ANGLE = 0;
        private const int MAX_ANGLE = 359;
        private const double STROKE_THICKNESS = 10;
        private const int UPDATE_PERIOD = 50;

        private int _angle = MAX_ANGLE; // valid range is MIN_ANGLE to MAX_ANGLE
        private double _radius = 100;
        private DispatcherTimer _timer = new DispatcherTimer();

        #endregion fields
        #region constructors

        /// <summary>
        /// AnimatedCursor constructor.
        /// </summary>
        public AnimatedCursor()
        {
            InitializeComponent();
        }

        #endregion constructors
        #region methods

        /// <summary>
        /// Timer tick event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_angle >= MIN_ANGLE && _angle <= MAX_ANGLE)
            {
                drawArcSegment();
                _angle--;
            }
            else
            {
                _angle = MAX_ANGLE;
                drawArcSegment();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void drawArcSegment()
        {
            Point center = new Point(0, _radius);
            double x = center.X + _radius * Math.Cos(_angle * Math.PI / 180);
            double y = center.Y + (_radius * Math.Sin(_angle * Math.PI / 180));
            xArcSegment.Point = new Point(x, y);
            bool isLargeArc = true;
            /*
            if (_angle > 270)
            {
                isLargeArc = false;
            }
            else if (_angle > 180)
            {
                isLargeArc = false;
            }
            else if (_angle > 90)
            {
                isLargeArc = false;
            }
            else
            {
                isLargeArc = false;
            }
            xArcSegment.IsLargeArc = isLargeArc;
             */
            Console.WriteLine("Angle:{0}\tisLargeArc:{1}\tEnd:{2},{3}", _angle, isLargeArc, x, y);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _radius = (xCanvas.ActualWidth / 2) - (STROKE_THICKNESS / 2);
            xPath.SetValue(Canvas.LeftProperty, _radius);
            xPath.SetValue(Canvas.TopProperty, STROKE_THICKNESS / 2);
            // xArcSegment.Size = new System.Windows.Size(_radius, _radius);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, UPDATE_PERIOD);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        #endregion methods

    }
}
