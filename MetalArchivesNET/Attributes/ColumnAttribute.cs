using MetalArchivesNET.Attributes.Abstract;

namespace MetalArchivesNET.Attributes
{
    /// <summary>
    /// Property will be parsed if this attribute is set
    /// </summary>
    class ColumnAttribute : FieldDecoratorBase
    {
        /// <summary>
        /// Creates instance of attribute
        /// </summary>
        /// <param name="index">aaData's row's cell id</param>
        public ColumnAttribute(uint index)
        {
            Index = index;
        }

        public uint Index { get; private set; }

        string _baseValue;

        public void SetBaseValue(string baseValue)
        {
            _baseValue = baseValue;
        }

        /// <summary>
        /// Decorator's operation
        /// </summary>
        /// <returns>base value</returns>
        public override object GetValue()
        {
            return _baseValue;
        }
    }
}
