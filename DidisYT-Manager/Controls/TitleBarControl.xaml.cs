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

namespace DidiDerDenker.BirdsEyeView.Controls
{
    /// <summary>
    /// Interaktionslogik für TitleBarControl.xaml
    /// </summary>
    public partial class TitleBarControl : UserControl
    {
        public enum Operation
        {
            Close,
            Minimize,
            Maximize
        }

        public event EventHandler MinimizedChanged;
        public event EventHandler MaximizedChanged;
        public event EventHandler CloseChanged;
        public event MouseButtonEventHandler MouseDownChanged;

        public TitleBarControl()
        {
            InitializeComponent();
        }

        protected virtual void OnChanged(Operation operation)
        {
            switch (operation)
            {
                case Operation.Close:
                    this.CloseChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case Operation.Minimize:
                    this.MinimizedChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case Operation.Maximize:
                    this.MaximizedChanged?.Invoke(this, EventArgs.Empty);
                    break;
            }
            
        }

        protected virtual void OnMouseDownChanged(MouseButtonEventArgs e)
        {
            this.MouseDownChanged?.Invoke(this, e);
        }

        private void OnWindowMinimizeClick(object sender, RoutedEventArgs e)
        {
            this.OnChanged(Operation.Minimize);
        }

        private void OnWindowMaximizeClick(object sender, RoutedEventArgs e)
        {
            this.OnChanged(Operation.Maximize);
        }

        private void OnWindowCloseClick(object sender, RoutedEventArgs e)
        {
            this.OnChanged(Operation.Close);
        }

        private void OnTitlebarMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.OnMouseDownChanged(e);
        }
    }
}
