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
using System.Collections.Specialized;
using System.Windows;

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

        private DelegateCommand<Video> copyVideoCommand;
        private DelegateCommand<Video> editVideoCommand;
        private DelegateCommand<Video> deleteVideoCommand;
        private DelegateCommand planVideoCommand;
        #endregion

        #region constructor
        public BirdsEyeViewInterfaceViewModel()
        {
            DatabaseConnection.Default.GetAllClasses();
            DatabaseConnection.Default.GetAllProjects();
            DatabaseConnection.Default.GetAllVideos();

            this.Projects = Project.Projects;
            this.Videos = Video.Videos;

            this.ScheduledList = new CollectionViewSource { Source = this.Videos }.View;
            this.CapturedList = new CollectionViewSource { Source = this.Videos }.View;
            this.RenderedList = new CollectionViewSource { Source = this.Videos }.View;
            this.UploadedList = new CollectionViewSource { Source = this.Videos }.View;

            this.ScheduledList.Filter = new Predicate<object>(x => ((Video)x).Mode == Task.Capture);
            this.CapturedList.Filter = new Predicate<object>(x => ((Video)x).Mode == Task.Render);
            this.RenderedList.Filter = new Predicate<object>(x => ((Video)x).Mode == Task.Upload);
            this.UploadedList.Filter = new Predicate<object>(x => ((Video)x).Mode == Task.Release);

            this.ScheduledList.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            this.CapturedList.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            this.RenderedList.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            this.UploadedList.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

            foreach (Project project in this.Projects)
            {
                project.PropertyChanged += this.OnFilterChanged;
            }

            Video.Videos.CollectionChanged += this.OnCollectionChanged;

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

        #region commands
        public ICommand CopyVideoCommand
        {
            get
            {
                if(null == this.copyVideoCommand)
                {
                    this.copyVideoCommand = new DelegateCommand<Video>(this.CopyVideo, this.ParameterIsVideo);
                }

                return this.copyVideoCommand;
            }
        }

        public ICommand PlanVideoCommand
        {
            get
            {
                if (null == this.planVideoCommand)
                {
                    this.planVideoCommand = new DelegateCommand(this.PlanVideo);
                }

                return this.planVideoCommand;
            }
        }

        public ICommand EditVideoCommand
        {
            get
            {
                if (null == this.editVideoCommand)
                {
                    this.editVideoCommand = new DelegateCommand<Video>(this.EditVideo, this.ParameterIsVideo);
                }

                return this.editVideoCommand;
            }
        }

        

        public ICommand DeleteVideoCommand
        {
            get
            {
                if (null == this.deleteVideoCommand)
                {
                    this.deleteVideoCommand = new DelegateCommand<Video>(this.DeleteVideo, this.ParameterIsVideo);
                }

                return this.deleteVideoCommand;
            }
        }

        
        #endregion

        #region private methods

        private bool ParameterIsVideo(Video video)
        {
            return null != video;
        }

        private void CopyVideo(Video video)
        {
            Clipboard.SetText(video.ToString());
        }

        private void PlanVideo()
        {
            App.AppClient.ShowVideoEditDialog(null, DateTime.Now);
        }

        private void EditVideo(Video video)
        {
            App.AppClient.ShowVideoEditDialog(video, video.Date);
        }

        private void DeleteVideo(Video video)
        {
            this.Videos.Remove(video);
        }
        #endregion

        #region public methods
        public void RefreshView()
        {
            this.ScheduledList.Refresh();
            this.CapturedList.Refresh();
            this.RenderedList.Refresh();
            this.UploadedList.Refresh();
        }
        #endregion

        #region events
        private void OnFilterChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsFilter"))
            {
                this.ScheduledList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Capture, this.Projects));
                this.CapturedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Render, this.Projects));
                this.RenderedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Upload, this.Projects));
                this.UploadedList.Filter = new Predicate<object>(x => Filter.SetFilter((Video)x, Task.Release, this.Projects));
            }
        }
        #endregion

        #region Event

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                if(e.OldItems.Count >= 1)
                {
                    DatabaseConnection.Default.DeleteVideo(e.OldItems[0] as Video);
                }
            }
        }
        #endregion
    }
}
