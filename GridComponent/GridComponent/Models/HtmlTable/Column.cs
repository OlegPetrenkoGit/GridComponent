using System;

namespace GridComponent.Models.HtmlTable
{
    public class Column
    {
        public string Name { get; set; }
        public bool ReadOnly { get; set; }
        public Type Type { get; set; }
    }
}