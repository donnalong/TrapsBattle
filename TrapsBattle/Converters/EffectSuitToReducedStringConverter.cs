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
    public class EffectSuitToReducedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            EffectSuit suit = (EffectSuit)value;

            string result;

            switch (suit)
            {
                case EffectSuit.Power:
                    result = "P";
                    break;
                case EffectSuit.Control:
                    result = "C";
                    break;
                case EffectSuit.Finesse:
                    result = "F";
                    break;
                case EffectSuit.Mental:
                    result = "M";
                    break;
                default:
                    result = "PCFM";
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
