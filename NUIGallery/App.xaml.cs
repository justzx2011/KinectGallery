using System;
using System.Windows;

namespace Ryerson.NUIGallery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region fields

        private static string METADATA_FILE = "gallery.csv"; // file that provides metadata for a gallery folder

        private static string _collectionPath = @"C:\\Temp\\MediaCollection";
        private static string _currentPath = _collectionPath;   

        #endregion fields
        #region properties

        /// <summary>
        /// Get the media collection root path.
        /// </summary>
        public string CollectionRoot
        {
            get
            {
                return _collectionPath;
            }
        }

        /// <summary>
        /// Get the current path.
        /// </summary>
        public string CurrentPath
        {
            get
            {
                return _currentPath;
            }
            set
            {
                _currentPath = value;
                PathChanged(this, new EventArgs());
            }
        }

        #endregion properties
        #region events

        /// <summary>
        /// Path changed event.
        /// </summary>
        public EventHandler PathChanged;

        #endregion events
        #region methods

        /// <summary>
        /// Application_Startup event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }

        /// <summary>
        /// Determine if the path is valid.  Path is valid if it is equal to or a subsidiary of the 
        /// COLLECTION_ROOT path.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        private bool IsValidPath(String Path)
        {
            bool isvalid = false;
            App app = (App)Application.Current;
            if (Path.Equals(_collectionPath))
            {
                // at the top level, show the main menu
                isvalid = true;
            }
            else if (Path.Contains(_collectionPath))
            {
                // in a subdirectory; show a control relevant to the content
                isvalid = true;
            }
            return isvalid;
        }

        #endregion methods

    }
}
