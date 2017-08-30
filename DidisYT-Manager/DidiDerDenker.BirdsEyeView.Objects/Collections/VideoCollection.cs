using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects.Collections
{
    public class VideoCollection : ObservableCollection<Video>
    {
        public VideoCollection() : base() { }
        public VideoCollection(List<Video> videos) : base(videos) { }
        public VideoCollection(IEnumerable<Video> videos) : base(videos) { }
    }
}
