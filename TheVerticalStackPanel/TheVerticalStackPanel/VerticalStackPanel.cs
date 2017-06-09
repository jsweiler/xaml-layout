using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TheVerticalStackPanel
{
    public class VerticalStackPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = new Size();

            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(availableSize);
                mySize.Width = Math.Max(mySize.Width, child.DesiredSize.Width);
                mySize.Width += child.DesiredSize.Height;
            }

            return mySize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();
            foreach (UIElement child in this.InternalChildren)
            {
                child.Arrange(new Rect(location, new Size(finalSize.Width, child.DesiredSize.Height)));
                location.Y += child.DesiredSize.Height;
            }

            return finalSize;
        }
    }
}
