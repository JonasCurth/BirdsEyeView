using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Video
    {
        #region Fields
        private int id;
        private string name;
        private DateTime? date;
        private Uri url;
        private string className;
        private string project;
        private int mode;
        private string episode;
        #endregion

        #region Constructor
        public Video()
            : this(0, null, null, new Uri(null), null, null, 0, null) { }

        public Video(int id,
                     string name,
                     DateTime? date,
                     string url,
                     string className,
                     string project,
                     int mode,
                     string episode)
            :this(id, name, date, new Uri(url), className, project, mode, episode) { }

        public Video(int id, 
                     string name, 
                     DateTime? date,
                     Uri url, 
                     string className, 
                     string project,
                     int mode,
                     string episode)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
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
            private set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public DateTime? Date
        {
            get { return this.date; }
            private set { this.date = value; }
        }

        public Uri URL
        {
            get { return this.url; }
            private set { this.url = value; }
        }

        public string Class
        {
            get { return this.className; }
            private set { this.className = value; }
        }

        public string Project
        {
            get { return this.project; }
            private set { this.project = value; }
        }
        public int Mode
        {
            get { return this.mode; }
            private set { this.mode = value; }
        }
        public string Episode
        {
            get { return this.episode; }
            private set { this.episode = value; }
        }
        #endregion

        #region private and protected methods

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
