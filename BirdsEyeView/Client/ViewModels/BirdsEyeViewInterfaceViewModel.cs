using DidiDerDenker.BirdsEyeView.Command;
using DidiDerDenker.BirdsEyeView.Database;
using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Objects.Collections;
using DidiDerDenker.BirdsEyeView.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class BirdsEyeViewInterfaceViewModel : BaseViewModel
    {
        #region fields

        private DateTime? selectedDate;
        private ObservableCollection<Video> videos;
        private ObservableCollection<Project> projects;
        private ObservableCollection<Class> Classes;

        private ICollectionView scheduledList;
        private ICollectionView capturedList;
        private ICollectionView renderedList;
        private ICollectionView uploadedList;
        #endregion

        #region constructor
        public BirdsEyeViewInterfaceViewModel()
        {
            //this.SelectedDate = DateTime.Now;
            DatabaseConnection.Default.GetAllClasses();
            DatabaseConnection.Default.GetAllProjects();
            DatabaseConnection.Default.GetAllVideos();

            this.Projects = Project.Projects;
            this.Videos = Video.Videos;

            this.ScheduledList = new CollectionViewSource { Source = this.Videos }.View;
            this.CapturedList = new CollectionViewSource { Source = this.Videos }.View;
            this.RenderedList = new CollectionViewSource { Source = this.Videos }.View;
            this.UploadedList = new CollectionViewSource { Source = this.Videos }.View;

            this.ScheduledList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Capture);
            this.CapturedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Render);
            this.RenderedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Upload);
            this.UploadedList.Filter = new Predicate<object>(x => ((Video)x).Mode == (int)Task.Release);

            foreach (Project project in this.Projects)
            {
                project.PropertyChanged += this.OnFilterChanged;
            }

        }
        #endregion

        #region public/protected properties
        public DateTime? SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Video> Videos
        {
            get { return this.videos; }
            set
            {
                this.videos = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Project> Projects
        {
            get { return this.projects; }
            set
            {
                this.projects = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView ScheduledList
        {
            get { return this.scheduledList; }
            set
            {
                this.scheduledList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView CapturedList
        {
            get { return this.capturedList; }
            set
            {
                this.capturedList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView RenderedList
        {
            get { return this.renderedList; }
            set
            {
                this.renderedList = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView UploadedList
        {
            get { return this.uploadedList; }
            set
            {
                this.uploadedList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region private methods
        #endregion

        #region public methods

        #endregion

        #region events
        private void OnFilterChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsFilter"))
            {
                this.Videos.Add(new Video(1, "Test", DateTime.Today, "http://youtube.com", Class.Classes.First(), Project.Projects.First(), 1, "001"));
                this.ScheduledList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Capture, this.Projects));
                this.CapturedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Render, this.Projects));
                this.RenderedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Upload, this.Projects));
                this.UploadedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Release, this.Projects));
            }
        }
        #endregion

    }
}
