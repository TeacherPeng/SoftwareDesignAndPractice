using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF00
{
    class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 输入为字符串，当输入为空时，返回Hide
            return 
                string.IsNullOrWhiteSpace(value as string) ? 
                Visibility.Hidden : 
                Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
