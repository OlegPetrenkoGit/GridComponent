using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GridComponent.Models
{
    public class Table
    {
        public List<List<Cell>> cells;
        public TagBuilder addButton;
        public Type entityType;

        public Table(Type entityType)
        {
            cells = new List<List<Cell>>();

        }
    }
}