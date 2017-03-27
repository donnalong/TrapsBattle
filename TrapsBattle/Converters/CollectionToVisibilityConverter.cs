using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TrapsBattle.Converters
{
    public class CollectionToVisibilityConverter : IValueConverter
    {
        public Visibility EmptyVisibility { get; set; } = Visibility.Collapsed;

        public Visibility ContentVisibility
        {
            get
            {
                return EmptyVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IList collection = (IList)value;

            return collection.Count > 0 ? ContentVisibility : EmptyVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
