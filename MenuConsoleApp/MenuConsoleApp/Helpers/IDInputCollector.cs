using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Helpers
{
    public class IDInputCollector
    {
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;

        public IDInputCollector(IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public int GetElementId()
        {
            var userInput = _iUIInput.ReadLine();
            if (!int.TryParse(userInput, out int id)) 
                _iUIDisplay.WriteLine("Błędne id, spróbuj ponownie");
            return id;
        }
    }
}
