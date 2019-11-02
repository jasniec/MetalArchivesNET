using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class ByteConverter : IConverter
    {
        public object Convert(object input)
        {
            return byte.Parse((string)input);
        }
    }
}
