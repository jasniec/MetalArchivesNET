using MetalArchivesNET.Attributes.Abstract;
using System;
using System.ComponentModel;

namespace MetalArchivesNET.Attributes
{
    /// <summary>
    /// Converts string into enum
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class EnumConverterAttribute : FieldDecoratorBase
    {
        /// <summary>
        /// Enum type. Can throw <see cref="NotSupportedException"/> if enumType is not an enum.
        /// </summary>
        /// <param name="enumType">Enum's type</param>
        public EnumConverterAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new NotSupportedException("Type must be enum");

            _enumType = enumType;
        }

        readonly Type _enumType;

        public override object GetValue()
        {
            string value = (string)base.GetValue();

            foreach (var field in _enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value)
                        return field.GetValue(null);
                }
                else
                {
                    if (field.Name == value)
                        return field.GetValue(null);
                }
            }

            return null;
        }
    }
}
