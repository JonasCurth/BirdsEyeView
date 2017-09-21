using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using Syncfusion.Linq;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class VideoEditDialogViewModel : BaseViewModel
    {
        #region fields
        private Video selectedVideo;
        private ListCollectionView projects;
        private ListCollectionView classes;
        #endregion

        #region constructor
        public VideoEditDialogViewModel(Video selectedVideo)
        {
            this.SelectedVideo = selectedVideo;

            this.Projects = (ListCollectionView)new CollectionViewSource { Source = Project.Projects }.View;
            this.Classes = (ListCollectionView)new CollectionViewSource { Source = Class.Classes }.View;

            this.SelectedVideo.PropertyChanged += this.OnSelectedVideoPropertyChanged;

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

        public DateTime Time
        {
            get { return this.SelectedVideo.Date; }
            set
            {
                this.SelectedVideo.Date = new DateTime(this.SelectedVideo.Date.Year,
                                                        this.SelectedVideo.Date.Month,
                                                        this.SelectedVideo.Date.Day,
                                                        value.Hour,
                                                        value.Minute,
                                                        value.Second);

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
        #endregion

        #region public methods

        #endregion
    }
}
