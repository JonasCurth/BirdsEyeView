using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Class : DatabaseObject
    {
        #region fields
        string id;
        string name;
        string format;
        string scheduleFormat;
        SolidColorBrush color;
        #endregion

        #region constructor
        public Class(string id, string name, string colorCode, string format, string scheduleFormat)
        {
            this.Id = id;
            this.Name = name;
            this.Format = format;
            this.ScheduleFormat = scheduleFormat;

            this.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorCode));
            
            Classes.Add(this);
        }
        #endregion

        #region public properties
        public string Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged();
            }
        }

        public string Format
        {
            get { return this.format; }
            set
            {
                this.format = value;
                OnPropertyChanged();
            }
        }

        public string ScheduleFormat
        {
            get { return this.scheduleFormat; }
            set
            {
                this.scheduleFormat = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<Class> Classes
        {
            get;
            private set;
        } = new ObservableCollection<Class>();

        public SolidColorBrush Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        #endregion

        #region private protected methods

        #endregion

        #region public methods
        public static Class GetClassByName(string name)
        {

            foreach (Class c in Classes)
            {
                if(c.Name == name)
                {
                    return c;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    }
}
