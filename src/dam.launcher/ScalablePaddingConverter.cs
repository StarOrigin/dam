using DevExpress.Xpf.LayoutControl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace org.starorigin.dam.launcher
{
    public class ScalablePaddingConverter : IValueConverter
    {
        public double MinPadding { get; set; }
        public ScalablePaddingConverter()
        {
            MinPadding = 35;
        }
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var controlHeight = (double)value;
            double desiredContentHeight = 1 * Tile.LargeHeight + 1 * Tile.SmallHeight + 1 * TileLayoutControl.DefaultItemSpace + 20;
            double paddingY = Math.Floor(Math.Max(0d, controlHeight - desiredContentHeight) / 2d);
            paddingY = Math.Max(MinPadding, Math.Min(paddingY, TileLayoutControl.DefaultPadding.Top));
            double relativePadding = (paddingY - MinPadding) / (TileLayoutControl.DefaultPadding.Top - MinPadding) * 0.7;
            double paddingX = Math.Floor(MinPadding + relativePadding * (TileLayoutControl.DefaultPadding.Left - MinPadding));
            return new Thickness(paddingX, paddingY, paddingX, paddingY);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
