using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Video : DatabaseObject
    {
        #region Fields
        private int id;
        private string name;
        private DateTime date;
        private DateTime endDate;
        private string url;
        private Class c;
        private Project project;
        private Task mode;
        private string episode;
        #endregion

        #region Constructor
        public Video()
            : this(-1, null, new DateTime(), null, null, null, 0, null) { }

        public Video(DateTime selectedDate)
            : this(-1, null, selectedDate, null, null, null, 0, null) { }

        public Video(int id, 
                     string name, 
                     DateTime date,
                     string url, 
                     Class c, 
                     Project project,
                     Task mode,
                     string episode)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.EndDate = this.Date.AddHours(1);
            this.URL = url;
            this.Class = c;
            this.Project = project;
            this.Mode = mode;
            this.Episode = episode;
            
            if(this.Name != null &&
               this.Class != null &&
               this.Project != null)
            {
                Videos.Add(this);
            }
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

        public string URL
        {
            get { return this.url; }
            set
            {
                this.url = value;
                OnPropertyChanged();
            }
        }

        public Class Class
        {
            get { return this.c; }
            set
            {
                this.c = value;
                OnPropertyChanged();
            }
        }

        public Project Project
        {
            get { return this.project; }
            set
            {
                this.project = value;
                OnPropertyChanged();
            }
        }
        public Task Mode
        {
            get { return this.mode; }
            set
            {
                this.mode = value;
                OnPropertyChanged();
            }
        }
        public string Episode
        {
            get { return this.episode; }
            set
            {
                this.episode = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                if(null != this.Class)
                {
                    return this.Class.Color;
                }

                return null;
            }
        }

        public string Subject
        {
            get
            {
                if(null != this.Project && null != this.Class)
                {
                    if (String.IsNullOrEmpty(this.Project.ScheduleFormat))
                    {
                        return this.GetFormat(this.Class.ScheduleFormat);
                    }
                    else
                    {
                        return this.GetFormat(this.Project.ScheduleFormat);
                    }
                }

                return null;
            }
        }

        public static ObservableCollection<Video> Videos
        {
            get;
            set;
        } = new ObservableCollection<Video>();
        #endregion

        #region private and protected methods
        private string GetFormat(string format)
        {
            return format.Replace(FormatKey.ID, this.Id.ToString() ?? String.Empty).
                    Replace(FormatKey.NAME, this.Name ?? String.Empty).
                    Replace(FormatKey.DATE, this.Date.ToString() ?? String.Empty).
                    Replace(FormatKey.ENDDATE, this.EndDate.ToString() ?? String.Empty).
                    Replace(FormatKey.URL, this.URL ?? String.Empty).
                    Replace(FormatKey.CLASS, this.Class.ToString() ?? String.Empty).
                    Replace(FormatKey.PROJECT, this.Project.ToString() ?? String.Empty).
                    Replace(FormatKey.MODE, this.Mode.ToString() ?? String.Empty).
                    Replace(FormatKey.EPISODE, this.Episode ?? String.Empty);
        }
        #endregion

        #region public methods
        public void Update(Video newVideo)
        {
            this.Id = newVideo.Id;
            this.Name = newVideo.Name;
            this.Date = newVideo.Date;
            this.EndDate = newVideo.EndDate;
            this.URL = newVideo.URL;
            this.Class = newVideo.Class;
            this.Project = newVideo.Project;
            this.Mode = newVideo.Mode;
            this.Episode = newVideo.Episode;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.Project.Format))
            {
                return this.GetFormat(this.Class.Format);
            }
            else
            {
                return this.GetFormat(this.Project.Format);
            }
        }

        public static Video GetVideoBySubjectAndDate(string name, DateTime date)
        {
            return Videos.Where(v => v.Subject.Equals(name) && v.Date.Equals(date)).FirstOrDefault();
        }
        #endregion
    }
}
