using System.Windows;

namespace Ryerson.KinectGallery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Application_Startup event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // KinectWindow kw = new KinectWindow();
            // kw.Visibility = Visibility.Visible;

            //MouseWindow mw = new MouseWindow();
            //mw.Visibility = Visibility.Visible;

            //MainWindow mw2 = new MainWindow();
            //mw2.Visibility = Visibility.Visible;

            MenuWindow mw3 = new MenuWindow();
            mw3.Visibility = Visibility.Visible;
        }

    }
}
