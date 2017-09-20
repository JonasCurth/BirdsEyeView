using DidiDerDenker.BirdsEyeView.Client.ViewModels;
using DidiDerDenker.BirdsEyeView.Client.Views;
using DidiDerDenker.BirdsEyeView.Objects;
using Syncfusion.UI.Xaml.Schedule;
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
        public static Client AppClient;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Views.BirdsEyeView view = new Views.BirdsEyeView();
            Current.MainWindow = view;

            BirdsEyeViewInterfaceViewModel vm = new BirdsEyeViewInterfaceViewModel();

            AppClient = new Client(view);

            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            AppClient.Show(vm);
        }
    }

    public class Client
    {
        #region fields
        private Window window = Application.Current.MainWindow;
        #endregion

        #region constructor
        public Client(Window window)
        {
            this.window = window;
        }
        #endregion

        #region public / protected properties

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

        public void ShowVideoEditDialog(Video video)
        {
            VideoEditDialog dialog = new VideoEditDialog();

            Video x = new Video(); x.Update(video); 

            VideoEditDialogViewModel vm = new VideoEditDialogViewModel(video ?? new Video());

            dialog.DataContext = vm;

            bool? result = dialog.ShowDialog();

            if (null != video)
            {
                if (result.GetValueOrDefault())
                {
                    video = x;
                }
            }
            else
            {
                if (result.GetValueOrDefault())
                {
                    Video.Videos.Add(vm.SelectedVideo);
                }
            }

            ((Views.BirdsEyeView)this.Window).Schedule.ItemsSource = null;
            ((Views.BirdsEyeView)this.Window).Schedule.ItemsSource = Video.Videos;
            
        }
        #endregion
    }
}
