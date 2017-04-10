using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrapsBattle.Controls
{
    public sealed partial class VariableSizedPanel : Panel
    {
        private double MaxWidthOfChildren;
        private double MaxHeightOfChildren;

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;

            foreach (UIElement child in Children)
            {
                // if there is not enough space left, put in new column
                if ((MaxHeightOfChildren + y) > finalSize.Height)
                {
                    y = 0;
                    x += MaxWidthOfChildren;
                }

                Rect finalRect = new Rect(x, y, MaxWidthOfChildren, MaxHeightOfChildren);

                child.Arrange(finalRect);

                y += MaxHeightOfChildren;
            }

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            MaxWidthOfChildren = 0;
            MaxHeightOfChildren = 0;

            // check the maximum width/height for all children
            foreach (UIElement child in Children)
            {
                child.Measure(availableSize);

                double desiredWidth = child.DesiredSize.Width;
                double desiredHeight = child.DesiredSize.Height;

                MaxWidthOfChildren = Math.Max(MaxWidthOfChildren, desiredWidth);
                MaxHeightOfChildren = Math.Max(MaxHeightOfChildren, desiredHeight);
            }

            // take the available height to compute how many items per column
            double itemsPerColumn = Math.Floor(availableSize.Height / MaxHeightOfChildren);

            // compute the number of columns needed
            double columns = Math.Ceiling(Children.Count / itemsPerColumn);

            return new Size(MaxWidthOfChildren * columns, MaxHeightOfChildren * itemsPerColumn);
        }
    }
}
