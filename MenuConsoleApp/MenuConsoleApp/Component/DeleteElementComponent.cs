using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MenuConsoleApp.Component
{
    public class DeleteElementComponent : IUIComponent
    {
        public string Name { get; set; }
    
        private readonly IDatabase _database;
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;

        public DeleteElementComponent(IDatabase database, IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            _database = database;
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
            Name = "Usuń książkę lub film\n";
        }
        public void Activate(List<string> ancestorNameList)
        {
            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(Name, ancestorNameList);

            IDSearcher iDSearcher = new IDSearcher(_iUIDisplay, _iUIInput);
            var ifElementWasFound = iDSearcher.FindElement(_database.ListOfElements);
            if (ifElementWasFound)
            {
                _iUIDisplay.WriteLine("Wpisz id aby usunąć daną pozycje");
                IDInputCollector iDInputCollector = new IDInputCollector(_iUIDisplay, _iUIInput);
                var elementIdToDelete = iDInputCollector.GetElementId();
                DeleteElement(elementIdToDelete, _database.ListOfElements);
            }
        }

        public void DeleteElement(int elementId, List<CommonItemModel> listOfElements)
        {
            var elementToDelete = listOfElements.Where(c => c.ElementId == elementId).FirstOrDefault();
            if (elementToDelete != null)
            {
                listOfElements.Remove(elementToDelete);
                _iUIDisplay.WriteLine("Usunięto wybraną pozycję");
            }
            else
            {
                _iUIDisplay.WriteLine("Obiekt o podanym Id nie istnieje");
            }
        }

    }
}
