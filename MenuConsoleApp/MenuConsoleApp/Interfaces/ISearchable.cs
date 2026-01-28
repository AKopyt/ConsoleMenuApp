using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Models;

namespace MenuConsoleApp.Interfaces
{
    public interface ISearchable
    {
        public bool ContainsText(string userInput);

    }
}
