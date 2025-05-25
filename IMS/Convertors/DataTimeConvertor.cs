using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Convertors;

namespace IMS.Convertors
{
    public class DateTimeConvertor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
                return dateTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); // Adjust format as needed
            return null;

        }



        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string stringValue && DateTime.TryParseExact(stringValue, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;
            return null;


        }
    }
}
