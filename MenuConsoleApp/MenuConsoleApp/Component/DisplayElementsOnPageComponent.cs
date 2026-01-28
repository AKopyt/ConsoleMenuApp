using MenuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Menu;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Helpers;

namespace MenuConsoleApp.Component
{
    public class DisplayElementsOnPageComponent : IUIComponent
    {
        public string Name { get; set; }
        private readonly IDatabase _database;
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;
        private int _pageNumber;
        private readonly int _pageSize;
        public const string exitFromMainMenu = "q";
        public DisplayElementsOnPageComponent(IDatabase database, int pageNumber, int pageSize, IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            Name = "Wyświetl wszystkie pozycje\n";
            _database = database;
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }

        public void Activate(List<string> ancestorNameList)
        {
            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(Name, ancestorNameList);
            DisplayElementsFromDatabase(_database.ListOfElements, _pageNumber, _pageSize);
            DisplayPageMenu(_database.ListOfElements);
        }

        public void DisplayPageMenu(List<CommonItemModel> listOfElements)
        {
            int pageSize = 10;
            PageCalculator pageCalculator = new PageCalculator();
            while (true)
            {
                _iUIDisplay.Write("Wybierz opcję:\n[1] Wyszukaj daną pozycje\n[2] Przejdź na kolejną stronę\n[3] Przejdź na wybraną stronę \n[q] Wyjdz");
                _iUIDisplay.WriteLine();
                var chosenOption = _iUIInput.ReadLine();

                if (int.TryParse(chosenOption, out int chosenOptionInt))
                {
                    switch (chosenOptionInt)
                    {
                        case 1:
                            SearchSpecificElement(listOfElements);
                            break;
                        case 2:
                            int amountOfPages = pageCalculator.CountAmountOfPages(listOfElements, pageSize);
                            if (_pageNumber < amountOfPages)
                            {
                                _pageNumber++;
                                DisplayElementsFromDatabase(listOfElements, _pageNumber, _pageSize);
                            }
                            else
                            {
                                _iUIDisplay.WriteLine("Kolejna strona nie istnieje");
                            }
                            break;
                        case 3:
                            MoveToSelectedPage(listOfElements);
                            break;
                        default:
                            _iUIDisplay.WriteLine("Niepoprawna opcja");
                            break;
                    }
                }
                else
                {
                    if (chosenOption == exitFromMainMenu) break;
                    else
                    {
                        _iUIDisplay.WriteLine("Wybierz poprawną opcje");
                    }
                }
            }
        }
      
        public void DisplayElementsFromDatabase(List<CommonItemModel> listOfElements, int pageNumber, int pageSize)
        {
            _iUIDisplay.WriteLine($"Strona {pageNumber} \n");
            IEnumerable<CommonItemModel> result = listOfElements.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            foreach (CommonItemModel item in result)
            {
                _iUIDisplay.WriteLine($"{item.Title} - {item.GetType().Name}");
                _iUIDisplay.WriteLine();
            }
        }

        public const string exitFromMenu = "Q";
        public void MoveToSelectedPage(List<CommonItemModel> listOfElements)
        {
            int pageSize = 10;
            PageCalculator pageCalculator = new PageCalculator();
            
            int amountOfPages = pageCalculator.CountAmountOfPages(listOfElements, pageSize);
            _iUIDisplay.WriteLine($"Wpisz numer strony od 1 do {amountOfPages} lub Q jeśli chcesz wyjść");
            
            while (true)
            {
                var userInput = _iUIInput.ReadLine();

                if ((!int.TryParse(userInput, out int pageNumber) ||
                    pageNumber < 1 || pageNumber > amountOfPages) && userInput!=exitFromMenu)
                {
                    _iUIDisplay.WriteLine($"Numer strony musi być liczbą z zakresu 1 do {amountOfPages}");
                    continue;
                }

                if (userInput == exitFromMenu) break;

                DisplayElementsFromDatabase(listOfElements, pageNumber, pageSize);
                break;
            }
        }

        public void SearchSpecificElement(List<CommonItemModel> listOfElements)
        {
            _iUIDisplay.WriteLine("Podaj szukaną frazę: ");
            var userInput = _iUIInput.ReadLine();
            List<CommonItemModel> foundedElementList = new List<CommonItemModel>();
            bool isElementFound = false;

            if (!String.IsNullOrEmpty(userInput))
            {
                foreach (CommonItemModel element in listOfElements)
                {
                    isElementFound = element.ContainsText(userInput);
                    if (isElementFound == true)
                    {
                        foundedElementList.Add(element);
                    }
                }
            }
            else
            {
                _iUIDisplay.WriteLine("Należy wpisać wartość");
            }

            if (foundedElementList.Count >0)
            {
                _iUIDisplay.WriteLine("Znaleziono: ");
                foreach (var element in foundedElementList)
                {
                    _iUIDisplay.WriteLine($"{element.ElementId} - {element.Title} - {element.GetType().Name}");
                }
            }
            else
            {
                _iUIDisplay.WriteLine("Nie znaleziono pasującej pozycji");
            }

        }
    }
}
