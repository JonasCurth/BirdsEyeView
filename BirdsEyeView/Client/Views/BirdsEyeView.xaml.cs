﻿using DidiDerDenker.BirdsEyeView.Client.ViewModels;
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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using DidiDerDenker.BirdsEyeView.Objects;

namespace DidiDerDenker.BirdsEyeView.Client.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class BirdsEyeView : ChromelessWindow
    {
        BirdsEyeViewInterfaceViewModel vm;

        public BirdsEyeView()
        {
            InitializeComponent();
            
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedDate"))
            {
                this.Schedule.MoveToDate(this.vm.SelectedDate.GetValueOrDefault());
                

            }
        }
        
        private void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.vm = this.DataContext as BirdsEyeViewInterfaceViewModel;

            this.vm.PropertyChanged += this.PropertyChanged;
        }

        private void OnAppointmentEditorOpening(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            
            App.AppClient.ShowVideoEditDialog((Video)e.Appointment, e.StartTime);
        }

        private void OnAppointmentDragging(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentDraggingEventArgs e)
        {
            e.Cancel = true;
        }

        private void OnAppointmentResizing(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentStartResizingEventArgs e)
        {
            e.Cancel = true;
        }

        private void OnContextMenuOpen(object sender, Syncfusion.UI.Xaml.Schedule.ContextMenuOpeningEventArgs e)
        {
            e.Cancel = true;
        }

        private void OnItemDoubleClick(object sender, RoutedEventArgs e)
        {
            Video video = (Video)((ListBoxItem)sender).Content;

            App.AppClient.ShowVideoEditDialog(video, video.Date);
        }
    }
}
