using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TrapsBattle.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility TrueVisibility { get; set; } = Visibility.Visible;

        public Visibility FalseVisibility
        {
            get
            {
                return TrueVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return object.Equals(value, true) ? TrueVisibility : FalseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return object.Equals(value, TrueVisibility) ? true : false;
        }
    }
}
