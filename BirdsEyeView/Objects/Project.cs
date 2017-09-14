using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Project : INotifyPropertyChanged
    {
        private string id;
        private string name;

        private bool isFilter;

        public event PropertyChangedEventHandler PropertyChanged;

        public Project()
        :this(null, null) { }

        public Project(string id, string name)
        {
            this.Id = id;
            this.Name = name;
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
        public bool IsFilter
        {
            get { return this.isFilter; }
            set
            {
                this.isFilter = value;
                OnPropertyChanged();
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
