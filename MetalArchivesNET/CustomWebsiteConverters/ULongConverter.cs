using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class ULongConverter : IConverter
    {
        public object Convert(object input)
        {
            return ulong.Parse((string)input);
        }
    }
}
