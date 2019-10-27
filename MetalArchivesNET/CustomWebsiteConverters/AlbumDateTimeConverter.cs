using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class AlbumDateTimeConverter : IConverter
    {
        public object Convert(object input)
        {
            string value = (string)input;

            value = value.Replace("th", "").Replace("st", "").Replace("nd", "").Replace("rd", "");

            value = ReplaceMonths(value);

            return DateTime.ParseExact(value, "MM dd, yyyy", null);
        }

        private string ReplaceMonths(string input)
        {
            input = input.Replace("January", "01");
            input = input.Replace("February", "02");
            input = input.Replace("March", "03");
            input = input.Replace("April", "04");
            input = input.Replace("May", "05");
            input = input.Replace("June", "06");
            input = input.Replace("July", "07");
            input = input.Replace("August", "08");
            input = input.Replace("September", "09");
            input = input.Replace("October", "10");
            input = input.Replace("November", "11");
            input = input.Replace("December", "12");

            return input;
        }

    }
}
