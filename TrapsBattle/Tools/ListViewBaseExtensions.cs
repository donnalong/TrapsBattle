using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrapsBattle.Tools
{
    static class ListViewBaseExtensions
    {
        public static T GetItemAtPoint<T>(this ListViewBase listViewBase, Point point)
        {
            foreach (object item in listViewBase.Items)
            {
                FrameworkElement frameworkElement = listViewBase.ContainerFromItem(item) as FrameworkElement;

                if (frameworkElement != null && listViewBase.IsPointInElement(frameworkElement, point))
                {
                    if (item.GetType() == typeof(T))
                    {
                        return (T)Convert.ChangeType(item, typeof(T));
                    }
                }
            }

            return default(T);
        }

        public static Rect? GetBoundingRectForItem(this ListViewBase listViewBase, object item)
        {
            FrameworkElement frameworkElement = listViewBase.ContainerFromItem(item) as FrameworkElement;

            if(frameworkElement != null)
            {
                Rect rect = frameworkElement.GetBoundingRect();

                return rect;
            }

            return null;
        }
    }
}
