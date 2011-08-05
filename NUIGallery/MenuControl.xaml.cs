using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ryerson.NUIGallery
{
    #region delegates

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MenuClickedHandler(object sender, EventArgs e);

    #endregion delegates

    /// <summary>
    /// On screen menu that uses mouse or NUI control for navigation.
    /// </summary>
    public partial class MenuControl : UserControl
    {
        #region fields
        #endregion fields

        #region properties
        #endregion properties
        
        #region events

        /// <summary>
        /// Menu clicked event
        /// </summary>
        public event EventHandler MenuClicked;

        /// <summary>
        /// Navigate up event.
        /// </summary>
        public event EventHandler NavigateUp;

        #endregion events
        #region constructors

        /// <summary>
        /// 
        /// </summary>
        public MenuControl()
        {
            InitializeComponent();
        }

        #endregion constructors
        #region methods

        /// <summary>
        /// Size and position the menu on the canvas, based on spacing ratios.
        /// </summary>
        private void sizeAndPositionComponents()
        {
            // main menu 
            double height = this.ActualHeight - (this.ActualHeight * 0.156 * 2);
            double width = this.ActualWidth - (this.ActualWidth * 0.1 * 2);
            double left = this.ActualWidth * 0.1;
            double top = this.ActualHeight * 0.156;
            mainmenugrid.SetValue(Canvas.HeightProperty, height);
            mainmenugrid.SetValue(Canvas.WidthProperty, width);
            mainmenugrid.SetValue(Canvas.LeftProperty, left);
            mainmenugrid.SetValue(Canvas.TopProperty, top);

            // top edge control
            height = this.ActualHeight * 0.13;
            width = this.ActualWidth - (this.ActualWidth * 0.1 * 2);
            left = this.ActualWidth * 0.1;
            top = 0;
            topEdge.SetValue(Canvas.HeightProperty, height);
            topEdge.SetValue(Canvas.WidthProperty, width);
            topEdge.SetValue(Canvas.LeftProperty, left);
            topEdge.SetValue(Canvas.TopProperty, top);

            // bottom edge control
            height = this.ActualHeight * 0.13;
            width = this.ActualWidth - (this.ActualWidth * 0.1 * 2);
            left = this.ActualWidth * 0.1;
            double bottom = 0;
            bottomEdge.SetValue(Canvas.HeightProperty, height);
            bottomEdge.SetValue(Canvas.WidthProperty, width);
            bottomEdge.SetValue(Canvas.LeftProperty, left);
            bottomEdge.SetValue(Canvas.BottomProperty, bottom);

            // left edge control
            height = this.ActualHeight - (this.ActualHeight * 0.156 * 2);
            width = this.ActualWidth * 0.083;
            left = 0;
            top = this.ActualHeight * 0.156;
            leftEdge.SetValue(Canvas.HeightProperty, height);
            leftEdge.SetValue(Canvas.WidthProperty, width);
            leftEdge.SetValue(Canvas.LeftProperty, left);
            leftEdge.SetValue(Canvas.TopProperty, top);

            // right edge control
            height = this.ActualHeight - (this.ActualHeight * 0.156 * 2);
            width = this.ActualWidth * 0.083;
            double right = 0;
            top = this.ActualHeight * 0.156;
            rightEdge.SetValue(Canvas.HeightProperty, height);
            rightEdge.SetValue(Canvas.WidthProperty, width);
            rightEdge.SetValue(Canvas.RightProperty, right);
            rightEdge.SetValue(Canvas.TopProperty, top);
        }

        /// <summary>
        /// UserControl loaded event handler. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            sizeAndPositionComponents();
        }

        /// <summary>
        /// UserControl size changed event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeAndPositionComponents();
        }

        private void tile1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        private void tile2_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        private void tile3_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        private void tile4_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_NavigateUp_Click(object sender, RoutedEventArgs e)
        {
            NavigateUp(this, new EventArgs());
        }

        private void rightEdge_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        private void bottomEdge_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        private void leftEdge_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString() + " mouse click");
            MenuClicked(this, new EventArgs());
        }

        #endregion methods

    }
}
