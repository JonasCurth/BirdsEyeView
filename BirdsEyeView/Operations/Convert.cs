using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Operations
{
    public static class Convert
    {
        public static DateTime ToDateTime(string date, string time)
        {
            if(String.IsNullOrEmpty(date) || String.IsNullOrEmpty(time))
            {
                return new DateTime();
            }

            DateTime d = System.Convert.ToDateTime(date);
            DateTime t = System.Convert.ToDateTime(time);

            return d.Date.Add(t.TimeOfDay);
        }
    }
}
