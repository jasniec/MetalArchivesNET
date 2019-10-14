using MetalArchivesNET.Attributes.Abstract;
using System;
using System.Text.RegularExpressions;

namespace MetalArchivesNET.Attributes
{
    /// <summary>
    /// Extracts regex group from string. Throws <see cref="Exception"/> when match won't succeed
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    class RegexConverterAttribute : FieldDecoratorBase
    {
        public RegexConverterAttribute(string regex)
        {
            _regex = regex;
        }

        readonly string _regex;

        public override object GetValue()
        {
            string value = (string)base.GetValue();

            var match = Regex.Match(value, _regex);

            if (!match.Success)
                throw new Exception("regex parse went wrong");

            return match.Groups[1].Value;
        }

    }
}
