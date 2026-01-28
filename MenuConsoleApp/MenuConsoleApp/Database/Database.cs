using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;

namespace MenuConsoleApp.Database
{
    public class Database : IDatabase
    {
        public List<CommonItemModel> ListOfElements { get; set; }

        public Database()
        {
            ListOfElements = new List<CommonItemModel>();
        }

        public void AddElement(CommonItemModel item)
        {
            var highestId = ListOfElements.Any() ? ListOfElements.Max(x => x.ElementId) : 0;
            item.ElementId = highestId + 1;
            ListOfElements.Add(item);
        }
    }
}