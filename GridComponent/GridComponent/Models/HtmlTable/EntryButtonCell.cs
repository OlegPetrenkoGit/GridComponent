using System.Web.Mvc;
using GridComponent.Models.HtmlTable.Interface;

namespace GridComponent.Models.HtmlTable
{
    public class EntryButtonCell : IEntryCell
    {
        public object Value { get { return Name; } }

        public string Name { get; set; }

        public TagBuilder ToHtmlTag()
        {
            string function = string.Empty;
            string className = string.Empty;
            switch (Name)
            {
                case "Edit":
                    {
                        function = "EditEntity()";
                        className = "button-edit";
                        break;
                    }
                case "Delete":
                    {
                        function = "deleteEntity()";
                        className = "button-delete";
                        break;
                    }
            }

            return new TagBuilder("td")
            {
                InnerHtml = (new TagBuilder("button")
                {
                    Attributes =
                    {
                        { "ng-click", function },
                        { "class", className }
                    },
                    InnerHtml = Name
                }).ToString()
            };
        }
    }
}