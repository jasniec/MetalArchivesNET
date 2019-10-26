using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.CustomWebsiteConverters
{
    class EnumDescriptionConverter<T> : IConverter where T : Enum
    {
        public object Convert(object input)
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == (string)input)
                        return field.GetValue(null);
                }
                else
                {
                    if (field.Name == (string)input)
                        return field.GetValue(null);
                }
            }

            return null;
        }
    }
}
