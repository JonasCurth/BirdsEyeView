using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region private methods
        #endregion

        #region public methods

        #endregion

        #region events

        #endregion

    }
}
