namespace MetalArchivesNET.Attributes.Abstract
{
    interface IConverterDecorator
    {
        object GetValue();
        void SetDecorator(IConverterDecorator converterDecorator);
    }
}
