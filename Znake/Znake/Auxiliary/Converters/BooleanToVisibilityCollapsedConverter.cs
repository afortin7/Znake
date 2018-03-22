﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Znake.Auxiliary.Converters
{
    class BooleanToVisibilityCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            return (flag ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
