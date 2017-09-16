﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Uri url;
        private Class c;
        private Project project;
        private int mode;
        private string episode;
        #endregion

        #region Constructor
        public Video()
            : this(0, null, new DateTime(), new Uri(null), null, null, 0, null) { }

        public Video(int id,
                     string name,
                     DateTime date,
                     string url,
                     Class c,
                     Project project,
                     int mode,
                     string episode)
            :this(id, name, date, new Uri(url), c, project, mode, episode) { }

        public Video(int id, 
                     string name, 
                     DateTime date,
                     Uri url, 
                     Class c, 
                     Project project,
                     int mode,
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
            
            Videos.Add(this);
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
                return this.Class.Color;
            }
        }

        public string Subject
        {
            get
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
            return format.Replace(FormatKey.ID, this.Id.ToString()).
                    Replace(FormatKey.NAME, this.Name.ToString()).
                    Replace(FormatKey.DATE, this.Date.ToString()).
                    Replace(FormatKey.ENDDATE, this.EndDate.ToString()).
                    Replace(FormatKey.URL, this.URL.ToString()).
                    Replace(FormatKey.CLASS, this.Class.ToString()).
                    Replace(FormatKey.PROJECT, this.Project.ToString()).
                    Replace(FormatKey.MODE, this.Mode.ToString()).
                    Replace(FormatKey.EPISODE, this.Episode.ToString());
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
            if (String.IsNullOrEmpty(this.Project.Format))
            {
                return this.GetFormat(this.Class.Format);
            }
            else
            {
                return this.GetFormat(this.Project.Format);
            }
        }
        #endregion
    }
}
