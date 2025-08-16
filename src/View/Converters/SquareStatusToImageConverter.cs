using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace View.Converters
{
    class SquareStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SquareStatus squareStatus = (SquareStatus)value;
            string imagePath = "";

            if (squareStatus == SquareStatus.Mine)
            {
                imagePath = "../Images/mine.png";
            }
            else if (squareStatus == SquareStatus.Flagged)
            {
                imagePath = "../Images/flag.png";
            }
            return new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
