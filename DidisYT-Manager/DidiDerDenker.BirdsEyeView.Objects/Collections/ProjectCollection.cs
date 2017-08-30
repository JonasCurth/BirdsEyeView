using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects.Collections
{
    public class ProjectCollection : ObservableCollection<Project>
    {
        public ProjectCollection() : base() { }
        public ProjectCollection(List<Project> projects) : base(projects) { }
        public ProjectCollection(IEnumerable<Project> projects) : base(projects) { }
    }
}
