using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using GridComponent.Models.HtmlTable.Interface;

namespace GridComponent.Models.HtmlTable
{
    static class HtmlTableBuilder<T>
    {
        public static string CreateHtmlTable(List<T> entries)
        {
            var newTable = new Table<T>(entries);

            CreateHeader(newTable);
            CreateEntriesRows(newTable);
            CreateAddButton(newTable);

            return newTable.ToString();
        }

        private static void CreateHeader(Table<T> table)
        {
            var entityTypeProperties = typeof(T).GetRuntimeProperties().ToList();
            table.columns = new List<Column>(entityTypeProperties
                .Select(p => new Column
                {
                    Name = p.Name,
                    Type = p.PropertyType,
                    ReadOnly = !p.CanWrite
                })
                .ToList());
        }

        private static void CreateEntriesRows(Table<T> table)
        {
            foreach (var entry in table.userInput)
            {
                var entryColumns = new List<IEntryCell>();

                int entityId = 0;
                Func<Column, T, object> GetPropertyValue = (column, entity) =>
                {
                    var value = entity.GetType().GetProperty(column.Name).GetValue(entity);
                    if (column.Name == "Id")
                    {
                        entityId = (int)value;
                    }

                    return value;
                };

                table.columns.ForEach(col => entryColumns.Add(new EntryPropertyCell
                {
                    Column = col,
                    Value = GetPropertyValue(col, entry)
                }));

                entryColumns.AddRange(new List<EntryButtonCell>
                {
                    new EntryButtonCell{ Name = "Edit" },
                    new EntryButtonCell{ Name = "Delete" }
                });

                var tags = entryColumns.Select(column => column.ToHtmlTag()).ToList();
                table.entries.Add(tags);
            }
        }

        private static void CreateAddButton(Table<T> table)
        {
            var entityTypeName = typeof(T).Name;
            var inputSubmit = new TagBuilder("button")
            {
                Attributes =
                {
                    { "ng-click", "showAddEntity()" },
                    { "class", "button-add" },
                    { "ng-disabled", "buttonAddDisabled" }
                },
                InnerHtml = "Add " + entityTypeName
            };

            table.buttons.Add(inputSubmit);
        }
    }
}