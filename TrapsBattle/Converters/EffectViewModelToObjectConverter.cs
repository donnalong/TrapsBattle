using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapsBattle.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TrapsBattle.Converters
{
    public class EffectViewModelToObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            EffectViewModel effectViewModel = value as EffectViewModel;

            if(effectViewModel != null)
            {
                return effectViewModel;
            }

            return null;
        }
    }
}
