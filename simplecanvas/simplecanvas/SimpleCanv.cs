using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace simplecanvas
{
    public class SimpleCanv : Panel
    {


        public static double GetTop(DependencyObject obj)
        {
            return (double)obj.GetValue(TopProperty);
        }

        public static void SetTop(DependencyObject obj, double value)
        {
            obj.SetValue(TopProperty, value);
        }

        // Using a DependencyProperty as the backing store for Top.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopProperty =
            DependencyProperty.RegisterAttached("Top", typeof(double), typeof(SimpleCanv), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentArrange));



        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement item in this.InternalChildren)
            {
                item.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();
            foreach (UIElement item in this.InternalChildren)
            {
                location.Y = GetTop(item);
                item.Arrange(new Rect(location, item.DesiredSize));
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
