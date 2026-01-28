using MenuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Interfaces
{
    public interface IDatabase
    {
        public List<CommonItemModel> ListOfElements { get; set; }
        public void AddElement(CommonItemModel item);

    }
}
