using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StepperApp.Infrastructure.Converters
{
    /// <summary>
    /// Converts <see cref="bool"/> values to <see cref="Visibility"/> value
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                            object parameter, CultureInfo culture)
        {
            if (value is not bool _val || targetType != typeof(Visibility))
                return Visibility.Collapsed;

            if (parameter is string)
                _val = !_val;

            if (_val)
                return Visibility.Visible;

            return parameter is Visibility
                ? parameter
                : Visibility.Collapsed;
        }


        /// <summary> 
        /// Converts a value. 
        /// </summary>
        public object ConvertBack(object value, Type targetType,
                                object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && targetType == typeof(bool))
            {
                var _val = visibility;
                if (_val == Visibility.Visible)
                    return true;
                return false;
            }
            else throw new ArgumentException("Invalid argument/return type. " +
                "Expected argument: Visibility and return type: bool");
        }
    }
}
