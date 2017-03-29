using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrapsBattle.Controls
{
    internal class VariableSizedGridView : GridView
    {
        private double maxWidth;
        private double maxHeight;

        double fullWidth;
        double fullHeight;

        protected override Size ArrangeOverride(Size finalSize)
        {
            FrameworkElement frameworkElement;

            double x = 0;
            double y = 0;

            foreach (object item in Items)
            {
                frameworkElement = this.ContainerFromItem(item) as FrameworkElement;

                // if there is not enough space left, put in new column
                // si il n'a a pas assez d'espace, crée une nouvelle colonne
                if ((maxHeight + y) > fullHeight)
                {
                    y = 0;
                    x += maxWidth;
                }

                Rect newPos = new Rect(x, y, maxWidth, maxHeight);

                frameworkElement.Arrange(newPos);

                y += maxHeight;
            }

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            FrameworkElement frameworkElement;

            // check the maximum width/height for all children
            foreach (object item in Items)
            {
                frameworkElement = this.ContainerFromItem(item) as FrameworkElement;

                if(frameworkElement != null)
                {
                    frameworkElement.Measure(availableSize);

                    double desiredWidth = frameworkElement.DesiredSize.Width;
                    double desiredHeight = frameworkElement.DesiredSize.Height;

                    maxWidth = desiredWidth > maxWidth ? desiredWidth : maxWidth;
                    maxHeight = desiredHeight > maxHeight ? desiredHeight : maxHeight;
                }
            }

            if(maxHeight > 0)
            {
                // take the available height to compute how many items per column
                double itemsPerColumn = Math.Floor(availableSize.Height / maxHeight);

                // compute the number of columns needed
                double columns = Math.Ceiling(Items.Count / itemsPerColumn);

                Debug.WriteLine("Max width : " + maxWidth);
                Debug.WriteLine("Max height : " + maxHeight);
                Debug.WriteLine("Items per columns : " + itemsPerColumn);
                Debug.WriteLine("Columns : " + columns);

                fullWidth = maxWidth * columns;
                fullHeight = maxHeight * itemsPerColumn;
            }

            return new Size(fullWidth, fullHeight);
        }
    }
}
