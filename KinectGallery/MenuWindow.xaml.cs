using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Ryerson.KinectGallery
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void sizeAndPositionComponents()
        {
            // get current window size 
            double windowHeight = MenuWindow.GetWindow(this).ActualHeight;
            double windowWidth = MenuWindow.GetWindow(this).ActualWidth;
            double elementHeight = 0;
            double elementWidth = 0;
            double left = 0;
            double top = 0;

            // size components, set position
            elementHeight = windowHeight - 200;
            elementWidth = windowWidth - 200;
            mainmenugrid.SetValue(Canvas.HeightProperty, elementHeight);
            mainmenugrid.SetValue(Canvas.WidthProperty, elementWidth);

            left = (windowWidth - elementWidth) / 2;
            top = (windowHeight - elementHeight) / 2;
            mainmenugrid.SetValue(Canvas.LeftProperty, left);
            mainmenugrid.SetValue(Canvas.TopProperty, 100.0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sizeAndPositionComponents();

            // move the menu off screen
            double windowHeight = MenuWindow.GetWindow(this).ActualHeight;
            double windowWidth = MenuWindow.GetWindow(this).ActualWidth;
            mainmenugrid.SetValue(Canvas.TopProperty, windowHeight + 50);

            // animate the menu and move it on to the screen
            double elementHeight = windowHeight - 200;
            double top = (windowHeight - elementHeight) / 2;
            DoubleAnimation da = new DoubleAnimation();
            da.From = windowHeight + 50;
            da.To = top;
            da.Duration = new TimeSpan(0, 0, 0, 500);
            mainmenugrid.BeginAnimation(Canvas.TopProperty, da);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeAndPositionComponents();

            // move the menu off screen
            double windowHeight = MenuWindow.GetWindow(this).ActualHeight;
            double windowWidth = MenuWindow.GetWindow(this).ActualWidth;
            mainmenugrid.SetValue(Canvas.TopProperty, windowHeight + 50);

            // animate the menu and move it on to the screen
            double elementHeight = windowHeight - 200;
            double top = (windowHeight - elementHeight) / 2;
            DoubleAnimation da = new DoubleAnimation();
            da.From = windowHeight + 50;
            da.To = top;
            da.Duration = new TimeSpan(0, 0, 1);
            mainmenugrid.BeginAnimation(Canvas.TopProperty, da);

        }

    }
}
