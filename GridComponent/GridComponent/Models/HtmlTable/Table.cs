using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace GridComponent.Models.HtmlTable
{
    public class Table<T>
    {
        public List<Column> columns;
        public List<List<TagBuilder>> entries;
        public List<TagBuilder> buttons;
        public IEnumerable<T> userInput;

        public Table(IEnumerable<T> inputEntries)
        {
            userInput = inputEntries;

            entries = new List<List<TagBuilder>>();
            buttons = new List<TagBuilder>();
        }

        public override string ToString()
        {
            Func<List<TagBuilder>, Dictionary<string, string>, Tuple<List<TagBuilder>, Dictionary<string, string>>>
                CreateTuple = (tags, attributes) => new Tuple<List<TagBuilder>, Dictionary<string, string>>(tags, attributes);

            var rowsTagsToConvert = new List<Tuple<List<TagBuilder>, Dictionary<string, string>>>();

            var headerCells = new List<TagBuilder>();
            columns.ForEach(h => headerCells.Add(new TagBuilder("th") { InnerHtml = h.Name }));
            rowsTagsToConvert.Add(CreateTuple(headerCells, null));

            var entriesTags = entries.Select(e => CreateTuple(e, null)).ToList();
            entriesTags.ForEach(rowsTagsToConvert.Add);

            var rowButtons = new List<TagBuilder>();
            buttons.ForEach(b => rowButtons.Add(new TagBuilder("td") { InnerHtml = b.ToString() }));

            var buttonsRowAttributes = new Dictionary<string, string> { { "ng-show", "showAddEntityButtonRow" } };
            rowsTagsToConvert.Add(CreateTuple(rowButtons, buttonsRowAttributes));

            var rowsStringBuilder = new StringBuilder();
            rowsTagsToConvert.Select(hr => CreateHtmlTableRow(hr.Item1, hr.Item2))
                .ToList().ForEach(r => rowsStringBuilder.Append(r));

            var table = new TagBuilder("table")
            {
                Attributes = { { "class", "grid table table-striped table-bordered" } },
                InnerHtml = rowsStringBuilder.ToString()
            };
            return table.ToString();
        }

        private static string CreateHtmlTableRow(List<TagBuilder> tdElements, Dictionary<string, string> attributes)
        {
            var rowStringBuilder = new StringBuilder();
            tdElements.ForEach(r => rowStringBuilder.Append(r.ToString()));

            var tableRow = new TagBuilder("tr") { InnerHtml = rowStringBuilder.ToString() };

            attributes.ForEach(a => tableRow.Attributes.Add(a));
            var htmlTableRow = tableRow.ToString();

            return htmlTableRow;
        }
    }
}