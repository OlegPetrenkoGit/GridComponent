using System.Collections.Generic;
using System.Linq;

namespace GridComponent.Models.HtmlTable
{
    public class FormatSpecification
    {
        public List<PropertySpecification> Properties = new List<PropertySpecification>();

        public static FormatSpecification Create<T>(T entity)
        {
            var newFormatSpecification = new FormatSpecification
            {
                Properties = entity.GetType().GetProperties()
                    .Select(p => new PropertySpecification
                    {
                        Name = p.Name,
                        Type = p.PropertyType.ToString(),
                        ReadOnly = !p.CanWrite
                    }).ToList()
            };

            return newFormatSpecification;
        }
    }
}