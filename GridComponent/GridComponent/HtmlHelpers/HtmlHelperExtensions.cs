using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace GridComponent.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Grid<T>(this HtmlHelper htmlHelper, List<T> data)
        {
            var rows = new List<TagBuilder>();
            foreach (var element in data)
            {
                var newRow = new TagBuilder("tr");
                var newData = new TagBuilder("td")
                {
                    InnerHtml = element.ToString()
                };

                newRow.InnerHtml = newData.ToString(); ;
                rows.Add(newRow);
            }

            var rowsStringBuilder = new StringBuilder();
            rows.ForEach(r => rowsStringBuilder.Append(r.ToString()));

            var table = new TagBuilder("table")
            {
                InnerHtml = rowsStringBuilder.ToString()
            };
            
            return new MvcHtmlString(table.ToString());
        }
    }
}