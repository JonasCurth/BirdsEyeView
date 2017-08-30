using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Operations.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum e, Language language)
        {
            ResourceManager manager = new ResourceManager(typeof(EnumResources));

            string displayname = manager.GetString($"{language.ToString()}_{e.ToString()}");

            return String.IsNullOrWhiteSpace(displayname) ? e.ToString() : displayname;
        }
    }
}
