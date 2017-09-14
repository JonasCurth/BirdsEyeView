using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Objects.Collections;
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

        public static bool IsProject(Video video, ProjectCollection projectCollection)
        {
            return projectCollection.Any(p => video.Project.Equals(p.Name) && p.IsFilter) 
                || projectCollection.All(p => !p.IsFilter);
        }
        
        public static bool SetFilter(Video video, Task task, ProjectCollection projectCollection)
        {
            return IsTask(video, task) && IsProject(video, projectCollection);
        }
    }
}
