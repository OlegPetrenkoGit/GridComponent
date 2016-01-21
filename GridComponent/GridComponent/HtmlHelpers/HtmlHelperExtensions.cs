using System.Collections.Generic;
using System.Web.Mvc;
using GridComponent.Models;

namespace GridComponent.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Grid<TEntity>(this HtmlHelper htmlHelper, List<TEntity> data)
        {
            var table = HtmlTableBuilder.CreateHtmlTable(data);
            return new MvcHtmlString(table);
        }
    }
}