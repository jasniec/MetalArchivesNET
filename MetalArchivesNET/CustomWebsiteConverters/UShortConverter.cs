using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class UShortConverter : IConverter
    {
        public object Convert(object input)
        {
            if (ushort.TryParse((string)input, out ushort value))
                return value;

            return null;
        }
    }
}
