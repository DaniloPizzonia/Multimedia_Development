using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataGenerator {
    public class GetFilename:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string sItem = value.ToString();
            sItem = sItem.Substring(sItem.LastIndexOf("\\") + 1);
            sItem = sItem.Substring(0, sItem.IndexOf("."));
            return sItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
