using DidiDerDenker.BirdsEyeView.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DidisYT_Manager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnWindowMaximizeClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void OnWindowMinimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnTitlebarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount < 2)
                {
                    this.DragMove();
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }

        private void OnSelectedDateChanged(object sender, EventArgs e)
        {
            SelectedDateChangedEventArgs args = e as SelectedDateChangedEventArgs;

            if(null != args.SelectedDate)
            {
                this.Schedule.MoveToDate(args.SelectedDate.GetValueOrDefault());
            }
        }
    }
}
