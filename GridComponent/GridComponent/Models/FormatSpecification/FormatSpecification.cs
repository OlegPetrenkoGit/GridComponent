using System.Collections.Generic;
using System.Linq;

namespace GridComponent.Models.FormatSpecification
{
    public class FormatSpecification<T>
    {
        public List<PropertySpecification> Properties { get; set; }

        public FormatSpecification()
        {
            Properties = typeof(T).GetProperties()
                .Select(p => new PropertySpecification
                {
                    Name = p.Name,
                    Type = p.PropertyType.ToString(),
                    ReadOnly = p.Name == "Id" || !p.CanWrite
                }).ToList();
        }
    }
}