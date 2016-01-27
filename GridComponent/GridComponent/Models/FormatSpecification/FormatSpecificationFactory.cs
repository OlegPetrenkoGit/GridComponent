using System;

namespace GridComponent.Models.FormatSpecification
{
    public class FormatSpecificationFactory
    {
        public static object Create(string type)
        {
            Type genericType = typeof(FormatSpecification<>);
            Type[] genericTypeArguments = { Type.GetType(type) };
            Type genericCtor = genericType.MakeGenericType(genericTypeArguments);
            object typeFormatSpecification = Activator.CreateInstance(genericCtor);

            return typeFormatSpecification;
        }
    }
}