using DidiDerDenker.BirdsEyeView.Client.ViewModels;
using DidiDerDenker.BirdsEyeView.Client.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DidiDerDenker.BirdsEyeView.Client
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            Views.BirdsEyeView view = new Views.BirdsEyeView();
            Current.MainWindow = view;

            BirdsEyeViewInterfaceViewModel vm = new BirdsEyeViewInterfaceViewModel(Client.Default);

            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            Client.Default.Show(vm);
        }
    }

    public class Client
    {
        #region fields
        private static Client defaultInstance;
        private Window window;
        #endregion

        #region constructor
        public Client(Window window)
        {
            this.window = window;
        }

        public Client()
            : this(Application.Current.MainWindow) { }
        #endregion

        #region public / protected properties
        public static Client Default
        {
            get
            {
                if(null == defaultInstance)
                {
                    defaultInstance = new Client();
                }

                return defaultInstance;
            }
        }

        public Window Window
        {
            get { return this.window; }
        }
        #endregion

        #region private methods

        #endregion

        #region public methods
        public void CloseClient()
        {
            this.Window.Close();
        }

        public void Show(BaseViewModel vm)
        {
            this.Window.DataContext = vm;
            this.Window.Show();
        }

        public bool? ShowDialog(BaseViewModel vm)
        {
            this.Window.DataContext = vm;

            return this.Window.ShowDialog();
        }
        #endregion
    }
}
