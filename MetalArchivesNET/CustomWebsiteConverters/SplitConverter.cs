using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class SplitConverter : IConverter
    {
        public object Convert(object input)
        {
            string value = (string)input;

            return value.Split(',').Select(i => i.Trim()).ToList();

        }
    }
}
