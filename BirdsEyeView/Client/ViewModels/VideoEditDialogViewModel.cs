using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using Syncfusion.Linq;
using DidiDerDenker.BirdsEyeView.Command;
using System.Windows.Input;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class VideoEditDialogViewModel : BaseViewModel
    {
        #region fields
        private Video selectedVideo;
        private ListCollectionView projects;
        private ListCollectionView classes;

        private DelegateCommand deleteCommand;
        
        #endregion

        #region constructor
        public VideoEditDialogViewModel(Video selectedVideo)
        {
            this.SelectedVideo = selectedVideo;

            this.IsEditmode = this.SelectedVideo.Class != null && this.SelectedVideo.Project != null;

            this.Projects = (ListCollectionView)new CollectionViewSource { Source = Project.Projects }.View;
            this.Classes = (ListCollectionView)new CollectionViewSource { Source = Class.Classes }.View;

            this.SelectedVideo.PropertyChanged += this.OnSelectedVideoPropertyChanged;

            this.Classes.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            this.Projects.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

            if(this.SelectedVideo.Class == null)
            {
                this.SelectedVideo.Class = Class.Classes.OrderBy(c => c.Name).LastOrDefault();
            }

            this.Tasks = new ObservableCollection<Task>(Enum.GetValues(typeof(Task)).ToList<Task>());
            this.Tasks.Remove(Task.Unknow);
        }
        #endregion

        #region public properties
        public Video SelectedVideo
        {
            get { return this.selectedVideo; }
            private set { this.selectedVideo = value; }
        }

        public bool IsEditmode
        {
            get;
            set;
        }

        public ObservableCollection<Task> Tasks
        {
            get; 
        }

        public ListCollectionView Projects
        {
            get { return this.projects; }
            set
            {
                this.projects = value;
                OnPropertyChanged();
            }
        }

        public ListCollectionView Classes
        {
            get { return this.classes; }
            set
            {
                this.classes = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Time
        {
            get { return new TimeSpan(this.SelectedVideo.Date.Hour, this.SelectedVideo.Date.Minute, 0); }
            set
            {
                this.SelectedVideo.Date = new DateTime(this.SelectedVideo.Date.Year,
                                                        this.SelectedVideo.Date.Month,
                                                        this.SelectedVideo.Date.Day,
                                                        value.Hours,
                                                        value.Minutes,
                                                        value.Seconds);

                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return this.SelectedVideo.Date; }
            set
            {
                this.SelectedVideo.Date = new DateTime(value.Year,
                                                        value.Month,
                                                        value.Day,
                                                        this.SelectedVideo.Date.Hour,
                                                        this.SelectedVideo.Date.Minute,
                                                        this.SelectedVideo.Date.Second);

                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if(null == this.deleteCommand)
                {
                    this.deleteCommand = new DelegateCommand(this.Delete, this.CanDelete);
                }

                return this.deleteCommand;
            }
        }
        #endregion

        #region private and protected methods
        private void OnSelectedVideoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Class"))
            {
                this.Projects.Filter = new Predicate<object>(x => ((Project)x).Class == this.SelectedVideo.Class);
            }
            if (e.PropertyName.Equals("Date"))
            {
                this.SelectedVideo.EndDate = this.SelectedVideo.Date.AddHours(1);
            }
        }

        private bool CanDelete()
        {
            return this.IsEditmode;
        }

        public void Delete()
        {
            Video.Videos.Remove(this.SelectedVideo);
        }
        #endregion

        #region public methods

        #endregion
    }
}
