using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class VideoEditDialogViewModel : BaseViewModel
    {
        #region fields
        private Video selectedVideo;
        #endregion

        #region constructor
        public VideoEditDialogViewModel(Video selectedVideo)
        {
            this.SelectedVideo = selectedVideo;
        }
        #endregion

        #region public properties
        public Video SelectedVideo
        {
            get { return this.selectedVideo; }
            private set { this.selectedVideo = value; }
        }

        public ObservableCollection<Project> Projects
        {
            get { return Project.Projects; }
        }

        public ObservableCollection<Class> Classes
        {
            get { return Class.Classes; }
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

        #endregion

        #region public methods

        #endregion
    }
}
