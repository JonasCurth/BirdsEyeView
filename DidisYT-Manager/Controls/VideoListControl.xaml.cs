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
            DependencyProperty.Register("Task", typeof(Enum), typeof(VideoListControl));

        public VideoListControl()
        {
            InitializeComponent();
        }

        public Task Task
        {
            get { return (Task)this.GetValue(TaskProperty); }
            set { this.SetValue(TaskProperty, value); }
        } 
    }
}
