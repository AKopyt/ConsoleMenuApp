using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.UI
{
    public class ConsoleUIDisplay : IUIDisplay
    {
        public void WriteLine(string sentence)
        {
            Console.WriteLine(sentence);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string sentence)
        {
            Console.Write(sentence);
        }
    }
}
