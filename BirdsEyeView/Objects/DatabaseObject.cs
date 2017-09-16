using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class DatabaseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] FormatKeys = new string[] { "%Name%", "%Date%", "%EndDate%", "%URL%", "%Class%", "%Project%", "%Mode%", "%Episode%" };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
