using MetalArchivesNET.Attributes.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MetalArchivesNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    class RegexReplaceAttribute : FieldDecoratorBase
    {
        public RegexReplaceAttribute(string pattern, string replaceTo)
        {
            _pattern = pattern;
            _replaceTo = replaceTo;
        }

        readonly string _pattern, _replaceTo;

        public override object GetValue()
        {
            string value = (string)base.GetValue();

            return Regex.Replace(value, _pattern, _replaceTo);
        }
    }
}
