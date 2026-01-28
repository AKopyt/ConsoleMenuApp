using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.UI
{
    public class ConsoleUIInput : IUIInput
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
