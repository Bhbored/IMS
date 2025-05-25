using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Convertors
{
    public class IntConvertor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // Change from:
            if (value is decimal intvalue)
                return intvalue.ToString();

            // To:
            if (value is int intValue)
                return intValue.ToString();
            else if (value is decimal decimalValue)
                return decimalValue.ToString();

            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string svalue)
            {
                // Change the return type based on targetType
                if (targetType == typeof(int) || targetType == typeof(int?))
                    return int.TryParse(svalue, out int intResult) ? intResult : 0;
                else if (targetType == typeof(decimal) || targetType == typeof(decimal?))
                    return decimal.TryParse(svalue, out decimal decResult) ? decResult : 0m;
            }
            return null;
        }
    }
}
