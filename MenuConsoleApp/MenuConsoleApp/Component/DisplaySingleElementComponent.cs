using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Component
{
    public class DisplaySingleElementComponent : IUIComponent
    {
        public string Name { get; set; }

        private readonly IDatabase _database;
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;
        public DisplaySingleElementComponent(IDatabase database, IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            Name = "Wyświetl szczegóły pojedyńczej pozycji\n";
            _database = database;
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public void Activate(List<string> ancestorNameList)
        {
            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(Name, ancestorNameList);

            IDSearcher iDSearcher = new IDSearcher(_iUIDisplay, _iUIInput);
            var ifElementWasFound = iDSearcher.FindElement(_database.ListOfElements);
            if (ifElementWasFound)
            {
                _iUIDisplay.WriteLine("Wpisz id aby wyświetlić szczegóły danej pozycji");
                IDInputCollector iDInputCollector = new IDInputCollector(_iUIDisplay, _iUIInput);
                var elementIdToDisplay = iDInputCollector.GetElementId();
                FindAndShowSingleElementDetails(elementIdToDisplay, _database.ListOfElements);
            }
        }

        public void FindAndShowSingleElementDetails(int elementId, List<CommonItemModel> listOfElements)
        {
            var elementToDisplay = listOfElements.Where(c => c.ElementId == elementId).FirstOrDefault();
            if (elementToDisplay != null)
            {
                var detailsOfElement = elementToDisplay.DisplayDetails();
                _iUIDisplay.WriteLine(detailsOfElement);
            }
            else
            {
                _iUIDisplay.WriteLine("Obiekt o podanym Id nie istnieje");
            }
        }
    }
}
