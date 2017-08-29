using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DidiDerDenker.BirdsEyeView.Client.ViewModels
{
    public class BirdsEyeViewInterfaceViewModel : BaseViewModel
    {
        #region fields
        private DateTime? selectedDate;
        #endregion

        #region constructor
        public BirdsEyeViewInterfaceViewModel()
        {
            //this.SelectedDate = DateTime.Now;
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

        public Task Capture
        {
            get { return Task.Capture; }
        }

        public Task Render
        {
            get { return Task.Render; }
        }

        public Task Upload
        {
            get { return Task.Upload; }
        }

        public Task Release
        {
            get { return Task.Release; }
        }
        #endregion

        #region private methods
        #endregion

        #region public methods

        #endregion

        #region events

        #endregion

    }
}
