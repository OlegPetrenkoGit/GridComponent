using System.Web.Mvc;

namespace GridComponent.Models.HtmlTable.Interface
{
    public interface IEntryCell
    {
        string Name { get; }
        object Value { get; }

        TagBuilder ToHtmlTag();
    }
}