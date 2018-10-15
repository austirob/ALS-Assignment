using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XboxGamesUI.Converters
{
    // NOT USED AS DECIDED TO DO THIS IN AUTOMAPPER RESOLVER - AN ALTERNATIVE OPTION
    public class IntegerToStarConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // we convert the integer rating to an array of objects to generate the images in the itemsource
            if (value == null) return null;
            var intRating = System.Convert.ToInt32(value);
            var array = new object[intRating];
            return array;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
    }
}
