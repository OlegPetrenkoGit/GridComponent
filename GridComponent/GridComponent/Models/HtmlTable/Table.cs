using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace GridComponent.Models.HtmlTable
{
    public class Table<T>
    {
        public List<Column> columns;
        public List<List<TagBuilder>> entries;
        public List<TagBuilder> buttons;
        public List<T> userInput;

        public Table(List<T> inputEntries)
        {
            userInput = inputEntries;

            entries = new List<List<TagBuilder>>();
            buttons = new List<TagBuilder>();
        }

        public override string ToString()
        {
            var rowsTags = entries;

            var headerCells = new List<TagBuilder>();
            columns.ForEach(h => headerCells.Add(new TagBuilder("th") { InnerHtml = h.Name }));
            rowsTags.Insert(0, headerCells);

            var rowButtons = new List<TagBuilder>();
            buttons.ForEach(b => rowButtons.Add(new TagBuilder("td") { InnerHtml = b.ToString() }));
            rowsTags.Add(rowButtons);

            var rowsStringBuilder = new StringBuilder();
            rowsTags.Select(CreateHtmlTableRow).ToList().ForEach(r => rowsStringBuilder.Append(r));

            var table = new TagBuilder("table")
            {
                Attributes = { { "class", "grid table table-striped table-bordered" } },
                InnerHtml = rowsStringBuilder.ToString()
            };
            return table.ToString();
        }

        private static string CreateHtmlTableRow(List<TagBuilder> tdElements)
        {
            var rowStringBuilder = new StringBuilder();
            tdElements.ForEach(r => rowStringBuilder.Append(r.ToString()));

            var tableRow = new TagBuilder("tr") { InnerHtml = rowStringBuilder.ToString() };
            return tableRow.ToString();
        }
    }
}