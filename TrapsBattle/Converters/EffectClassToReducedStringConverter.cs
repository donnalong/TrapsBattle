using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapsBattle.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TrapsBattle.Converters
{
    public class EffectClassToReducedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            EffectClass suit = (EffectClass)value;

            string result;

            switch (suit)
            {
                case EffectClass.Attack:
                    result = "A";
                    break;
                case EffectClass.Defense:
                    result = "D";
                    break;
                case EffectClass.Utility:
                    result = "U";
                    break;
                default:
                    result = "ADU";
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
