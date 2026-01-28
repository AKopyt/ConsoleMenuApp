using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Menu
{
    public class MenuPosition
    {
        public string Name { get; set; } = string.Empty;
        public required IUIComponent Component { get; set; }

    }
}
