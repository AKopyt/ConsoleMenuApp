using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;

namespace MenuConsoleApp.Helpers
{
    public class IDSearcher
    {
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;
        public IDSearcher(IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public bool FindElement(List<CommonItemModel> listOfElements) 
        {
            bool isElementFound = false;
            var userInput = string.Empty;
            List<CommonItemModel> foundedElementList = new List<CommonItemModel>();

            do
            {
                _iUIDisplay.WriteLine("Podaj informacje o obiekcie, który chcesz znaleźć, aby odczytac jego ID: ");
                userInput = _iUIInput.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    foreach (var element in listOfElements)
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
            } while (string.IsNullOrEmpty(userInput));

            if (foundedElementList.Count >0)
            {
                _iUIDisplay.WriteLine("Znaleziono: ");
                foreach (var element in foundedElementList)
                {
                    _iUIDisplay.WriteLine($"{element.ElementId} - {element.Title} - {element.GetType().Name}");
                    isElementFound = true;
                }
            }
            else
            {
                _iUIDisplay.WriteLine("Nie znaleziono pasującej pozycji");
                isElementFound = false;
            }
            return isElementFound;
        }
    }
}
