using MenuConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Helpers
{
    public class NamePath
    {
        private readonly IUIDisplay _iUIDisplay;
        public NamePath(IUIDisplay iUIDisplay)
        {
            _iUIDisplay = iUIDisplay;
        }
        public void ShowNamePath(string? Name, List<string> ancestorNameList)
        {
            foreach (var parentName in ancestorNameList)
            {
                if (Name != null)
                {
                    _iUIDisplay.Write(string.Join("/", parentName, Name));
                }
                else
                {
                    _iUIDisplay.Write(string.Join("/", parentName));
                }
            }
        }

        public void ShowNamePath( List<string> ancestorNameList)
        {
            ShowNamePath(null,  ancestorNameList);
        }
    }
}
