using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DidiDerDenker.BirdsEyeView.Operations
{
    public static class Filter
    {
        public static bool IsTask(Video video, Task task)
        {
            return video.Mode == (int)task;
        }

        public static bool IsProject(Video video, Project project)
        {
            return video.Project == project.Name;
        }
        
        public static bool SetFilter(bool taskFilter, bool projectFilter = true)
        {
            return taskFilter && projectFilter;
        }
    }
}
