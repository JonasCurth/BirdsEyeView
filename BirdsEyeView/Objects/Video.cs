using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Video : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string name;
        private DateTime date;
        private DateTime endDate;
        private Uri url;
        private string className;
        private string project;
        private int mode;
        private string episode;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public Video()
            : this(0, null, new DateTime(), new Uri(null), null, null, 0, null) { }

        public Video(int id,
                     string name,
                     DateTime date,
                     string url,
                     string className,
                     string project,
                     int mode,
                     string episode)
            :this(id, name, date, new Uri(url), className, project, mode, episode) { }

        public Video(int id, 
                     string name, 
                     DateTime date,
                     Uri url, 
                     string className, 
                     string project,
                     int mode,
                     string episode)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.EndDate = this.Date.AddHours(1);
            this.URL = url;
            this.Class = className;
            this.Project = project;
            this.Mode = mode;
            this.Episode = episode;
        }
        #endregion

        #region public properties
        public int Id
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

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
            set
            {
                this.endDate = value;
                OnPropertyChanged();
            }
        }

        public Uri URL
        {
            get { return this.url; }
            set
            {
                this.url = value;
                OnPropertyChanged();
            }
        }

        public string Class
        {
            get { return this.className; }
            set
            {
                this.className = value;
                OnPropertyChanged();
            }
        }

        public string Project
        {
            get { return this.project; }
            set
            {
                this.project = value;
                OnPropertyChanged();
            }
        }
        public int Mode
        {
            get { return this.mode; }
            private set
            {
                this.mode = value;
                OnPropertyChanged();
            }
        }
        public string Episode
        {
            get { return this.episode; }
            private set
            {
                this.episode = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                SolidColorBrush brush = null;
                switch (this.Class)
                {
                    case "Let's Play": brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#078e00")); break;
                    case "Didi TV": brush = new SolidColorBrush(Colors.Blue); break;
                    case "Best of": brush = new SolidColorBrush(Colors.DarkGreen); break;
                    default: brush = new SolidColorBrush(Colors.Pink); break;
                }

                return brush;
            }
        }

        public string Subject
        {
            get
            {
                string name = null;
                switch (this.Class)
                {
                    case "Let's Play": name = $"{this.Project} #{this.Episode}"; break;
                    case "Didi TV": name = $"{this.Project} #{this.Episode}"; break;
                    case "Best of": name = "Best of PietSmiet"; break;
                }

                return name;
            }
        }
        #endregion

        #region private and protected methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region public methods
        public void Update(Video newVideo)
        {
            this.Name = newVideo.Name;
            this.Date = newVideo.Date;
            this.URL = newVideo.URL;
            this.Class = newVideo.Class;
            this.Project = newVideo.Project;
            this.Mode = newVideo.Mode;
            this.Episode = newVideo.Episode;
        }

        public override string ToString()
        {
            //ToDo: Only for LetsPlays!
            return $"{this.Class} {this.Project} [Deutsch] #{this.Episode} {this.Name}";
        }
        #endregion
    }
}
