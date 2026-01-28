using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Interfaces
{
    public interface IUIDisplay
    {
        public void WriteLine(string sentence);
        public void WriteLine();
        public void Write(string sentence);
       
    }
}
