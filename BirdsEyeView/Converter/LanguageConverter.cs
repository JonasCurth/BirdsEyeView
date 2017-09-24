using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace DidiDerDenker.BirdsEyeView.Converter
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ObservableCollection<Task>)
            {
                ObservableCollection<Task> tasks = (ObservableCollection<Task>)value;
                Dictionary<Task, string> dict = new Dictionary<Task, string>();
                foreach (Task task in tasks)
                {
                    dict.Add(task, Application.Current.TryFindResource($"Task_{task.ToString()}_past").ToString());
                }

                return dict;
            }
            else if(value is Task)
            {
                Task task = (Task)value;
                KeyValuePair<Task, string> dict = new KeyValuePair<Task, string>(task, Application.Current.TryFindResource($"Task_{task.ToString()}_past").ToString());

                return dict;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ObservableCollection<Task>)
            {
                Dictionary<Task, string> dict = (Dictionary<Task, string>)value;

                ObservableCollection<Task> tasks = new ObservableCollection<Task>();
                foreach (KeyValuePair<Task, string> item in dict)
                {
                    tasks.Add(item.Key);
                }

                return tasks;
            }
            else if (value is KeyValuePair<Task, string>)
            {
                KeyValuePair<Task, string> pair = (KeyValuePair<Task, string>)value;

                return pair.Key;
            }

            return null;
        }
    }
}
