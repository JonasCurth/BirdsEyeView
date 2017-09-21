using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Project : DatabaseObject
    {
        private string id;
        private string name;
        private Class c;
        string format;
        string scheduleFormat;


        private bool isFilter;

        public Project()
        :this(null, null, null, null, null) { }

        public Project(string id, string name, Class c, string format, string scheduleFormat)
        {
            this.Id = id;
            this.Name = name;
            this.Class = c;
            this.Format = format;
            this.ScheduleFormat = scheduleFormat;
            
            Projects.Add(this);
        }

        public String Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Class Class
        {
            get { return this.c; }
            private set { this.c = value; }
        }
        public bool IsFilter
        {
            get { return this.isFilter; }
            set
            {
                this.isFilter = value;
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

        public static ObservableCollection<Project> Projects
        {
            get;
            private set;
        } = new ObservableCollection<Project>();

        public static Project GetProjectByName(string name)
        {

            foreach (Project project in Projects)
            {
                if (project.Name == name)
                {
                    return project;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
