using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TrapsBattle.Tools
{
    static class UIElementExtensions
    {
        public static Point TranslatePointToContainer(this UIElement container, FrameworkElement frameworkElement, Point point)
        {
            GeneralTransform generalTransform = container.TransformToVisual(frameworkElement);
            Rect rect = new Rect(0, 0, frameworkElement.ActualWidth, frameworkElement.ActualHeight);

            Rect transformedRect = generalTransform.TransformBounds(rect);
            
            Point transformedPoint = new Point();
            transformedPoint.X = point.X + transformedRect.X;
            transformedPoint.Y = point.Y + transformedRect.Y;

            return transformedPoint;
        }

        public static bool IsPointInElement(this UIElement container, FrameworkElement frameworkElement, Point point)
        {
            bool result;

            GeneralTransform generalTransform = frameworkElement.TransformToVisual(container);
            Rect rect = new Rect(0, 0, frameworkElement.ActualWidth, frameworkElement.ActualHeight);

            Rect transformedRect = generalTransform.TransformBounds(rect);

            result = transformedRect.Contains(point);

            return result;
        }
    }
}
