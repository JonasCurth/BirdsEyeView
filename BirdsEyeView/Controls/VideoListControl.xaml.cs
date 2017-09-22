using DidiDerDenker.BirdsEyeView.Objects;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DidiDerDenker.BirdsEyeView.Controls
{
    /// <summary>
    /// Interaktionslogik für VideoListControl.xaml
    /// </summary>
    public partial class VideoListControl : UserControl
    {
        public static DependencyProperty TaskProperty =
            DependencyProperty.Register("Task", typeof(string), typeof(VideoListControl));
        public static DependencyProperty FilteredListProperty =
            DependencyProperty.Register("FilteredList", typeof(ListCollectionView), typeof(VideoListControl));

        public event MouseButtonEventHandler LeftMouseButtonDoubleClick;


        public VideoListControl()
        {
            InitializeComponent();
        }

        public String Task
        {
            get { return (string)this.GetValue(TaskProperty); }
            set { this.SetValue(TaskProperty, value); }
        }

        public ListCollectionView FilteredList
        {
            get { return (ListCollectionView)this.GetValue(FilteredListProperty); }
            set { this.SetValue(FilteredListProperty, value); }
        }
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                LeftMouseButtonDoubleClick?.Invoke(sender, e);
            }
        }

        private void OnCopyClick(object sender, RoutedEventArgs e)
        {
            Video video = (Video)this.listbox.SelectedItem;

            Clipboard.SetText(video.ToString());
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            Video video = (Video)this.listbox.SelectedItem;

            Video.Videos.Remove(video);
        }
    }
}
