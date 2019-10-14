using System;

namespace MetalArchivesNET.Attributes.Abstract
{
    abstract class FieldDecoratorBase : Attribute, IConverterDecorator
    {
        protected IConverterDecorator decorator;

        public virtual object GetValue()
        {
            if (decorator != null)
                return decorator.GetValue();
            else
                return null;
        }

        public virtual void SetDecorator(IConverterDecorator converterDecorator)
        {
            decorator = converterDecorator;
        }
    }
}
