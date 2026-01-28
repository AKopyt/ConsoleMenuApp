using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Interfaces
{
    public interface IUIComponent
    {
        public string Name { get; set; }
        public void Activate(List<string> ancestorNameList);
    }
}
