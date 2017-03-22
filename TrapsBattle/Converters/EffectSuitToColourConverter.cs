using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapsBattle.ViewModels;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TrapsBattle.Converters
{
    public class EffectSuitToColourConverter : IValueConverter
    {
        public Color PowerColour = Colors.Red;
        public Color ControlColour = Colors.Green;
        public Color FinesseColour = Colors.Purple;
        public Color MentalColour = Colors.Blue;

        public Color NullColour = Colors.Black;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            EffectSuit suit = (EffectSuit)value;

            Color color;

            switch(suit)
            {
                case EffectSuit.Power:
                    color = PowerColour;
                    break;
                case EffectSuit.Control:
                    color = ControlColour;
                    break;
                case EffectSuit.Finesse:
                    color = FinesseColour;
                    break;
                case EffectSuit.Mental:
                    color = MentalColour;
                    break;
                default:
                    color = NullColour;
                    break;
            }

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
