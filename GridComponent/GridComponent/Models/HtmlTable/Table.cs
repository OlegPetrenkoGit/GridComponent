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
        public List<T> userInput;

        public Table(List<T> inputEntries)
        {
            userInput = inputEntries;

            entries = new List<List<TagBuilder>>();
            buttons = new List<TagBuilder>();
        }

        public override string ToString()
        {
            var rowsTagsToConvert = new List<Tuple<List<TagBuilder>, Dictionary<string, string>>>();


            var headerCells = new List<TagBuilder>();
            columns.ForEach(h => headerCells.Add(new TagBuilder("th") { InnerHtml = h.Name }));

            rowsTagsToConvert.Add(
                new Tuple<List<TagBuilder>, Dictionary<string, string>>(headerCells, null)
                );

            var entriesTags = entries
                .Select(e => new Tuple<List<TagBuilder>, Dictionary<string, string>>(e, null))
                .ToList();

            entriesTags.ForEach(rowsTagsToConvert.Add);

            var rowButtons = new List<TagBuilder>();
            buttons.ForEach(b => rowButtons.Add(new TagBuilder("td") { InnerHtml = b.ToString() }));

            rowsTagsToConvert.Add(
              new Tuple<List<TagBuilder>, Dictionary<string, string>>(
                  rowButtons,
                  new Dictionary<string, string>
                  {
                      {"ng-show", "showAddEntityButtonRow"}
                  })
              );

            var rowsStringBuilder = new StringBuilder();
            rowsTagsToConvert.Select(hr => CreateHtmlTableRow(hr.Item1, hr.Item2)).ToList().ForEach(r => rowsStringBuilder.Append(r));

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

            var tableRow = new TagBuilder("tr")
            {
                InnerHtml = rowStringBuilder.ToString()
            };

            attributes.ForEach(a => tableRow.Attributes.Add(a));
            var htmlTableRow = tableRow.ToString();

            return htmlTableRow;
        }
    }
}