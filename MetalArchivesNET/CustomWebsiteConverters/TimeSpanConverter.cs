using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class TimeSpanConverter : IConverter
    {
        public object Convert(object input)
        {
            string value = (string)input;

            int hours, minutes, seconds;

            var fragments = value.Split(':').Reverse();

            hours = fragments.Count() == 3 ? int.Parse(fragments.ElementAt(2)) : 0;
            minutes = int.Parse(fragments.ElementAt(1));
            seconds = int.Parse(fragments.ElementAt(0));

            return new TimeSpan(hours, minutes, seconds);
        }
    }
}
