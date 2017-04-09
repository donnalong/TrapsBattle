using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TrapsBattle.Converters
{
    public class IntegerToVisibilityConverter : IValueConverter
    {
        public Visibility GreaterThanZeroVisibility { get; set; } = Visibility.Visible;

        public Visibility ZeroVisibility
        {
            get
            {
                return GreaterThanZeroVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int number = (int)value;

            return number > 0 ? GreaterThanZeroVisibility : ZeroVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
