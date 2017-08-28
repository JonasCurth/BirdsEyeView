using sf = Syncfusion.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows;

namespace DidiDerDenker.BirdsEyeView.Controls
{
    /// <summary>
    /// Interaktionslogik für SmallCalenderControl.xaml
    /// </summary>
    public partial class SmallCalenderControl : UserControl
    {
        public event EventHandler SelectedDateChanged;

        public static DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", 
                    typeof(DateTime?), 
                    typeof(SmallCalenderControl), 
                    new FrameworkPropertyMetadata(null,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public DateTime? SelectedDate
        {
            get { return this.GetValue(SelectedDateProperty) as DateTime?; }
            set
            {
                this.SetValue(SelectedDateProperty, value);
                OnSelectedDateChanged();
            }
        }

        public SmallCalenderControl()
        {
            InitializeComponent();
        }

        protected virtual void OnSelectedDateChanged()
        {
            SelectedDateChanged?.Invoke(this, new SelectedDateChangedEventArgs(this.SelectedDate));
        }
    }

    public class SelectedDateChangedEventArgs : EventArgs
    {
        private readonly DateTime? selectedDate;

        public DateTime? SelectedDate
        {
            get { return this.selectedDate; }
        }

        public SelectedDateChangedEventArgs(DateTime? selectedDate)
        {
            this.selectedDate = selectedDate;
        }
    }
}
