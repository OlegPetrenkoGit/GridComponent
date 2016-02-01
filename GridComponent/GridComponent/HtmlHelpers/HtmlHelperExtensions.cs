using System.Collections.Generic;
using System.Web.Mvc;
using GridComponent.Models.HtmlTable;

namespace GridComponent.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Grid<T>(this HtmlHelper htmlHelper, IEnumerable<T> data)
        {
            var table = HtmlTableBuilder<T>.CreateHtmlTable(data);
            return new MvcHtmlString(table);
        }
    }
}