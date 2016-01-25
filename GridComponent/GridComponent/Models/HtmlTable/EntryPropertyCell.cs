using System;
using System.Web.Mvc;
using GridComponent.Models.HtmlTable.Interface;

namespace GridComponent.Models.HtmlTable
{
    public class EntryPropertyCell : IEntryCell
    {
        public Column Column { get; set; }
        public object Value { get; set; }

        public Type Type { get { return Column.Type; } }
        public string Name { get { return Column.Name; } }

        public TagBuilder ToHtmlTag()
        {
            return new TagBuilder("td")
            {
                InnerHtml = Value.ToString()
            };
        }
    }
}