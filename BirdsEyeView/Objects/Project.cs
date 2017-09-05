using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class Project
    {
        private string id;
        private string name;

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
    }
}
