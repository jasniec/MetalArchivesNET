using MetalArchivesNET.Attributes.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetalArchivesNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class DateTimeConverterAttribute : FieldDecoratorBase
    {
        public DateTimeConverterAttribute(string dateFormat)
        {
            _format = dateFormat;
        }

        readonly string _format;

        public override object GetValue()
        {
            string value = (string)base.GetValue();

            return DateTime.ParseExact(value, _format, null);
        }

    }
}
