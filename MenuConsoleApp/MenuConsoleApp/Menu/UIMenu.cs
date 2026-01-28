using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Menu
{

    public abstract class UIMenu : IUIComponent
    {
        public virtual string Name { get; set; } = string.Empty;

        protected virtual List<MenuPosition> MenuPositionList { get; set; } = new List<MenuPosition>();

        public const string exitFromMenu = "q";

        private IUIDisplay _iUIDisplay;
        private IUIInput _iUIInput;

        public UIMenu(IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }

        public void Activate(List<string> ancestorNameList)
        {
            while (true)
            {
                ShowActionInMenu(Name, ancestorNameList, MenuPositionList);
                var chosenOption = _iUIInput.ReadLine();

                if (int.TryParse(chosenOption, out int chosenOptionInt))
                {
                    chosenOptionInt -= 1;
                    if (chosenOptionInt >= 0 && chosenOptionInt <= MenuPositionList.Count - 1)
                    {
                        MenuPositionList[chosenOptionInt].Component.Activate(ancestorNameList);
                    }
                    else
                    {
                        _iUIDisplay.WriteLine("Niepoprawna opcja");
                    }
                }
                else
                {
                    if (chosenOption == exitFromMenu) break;
                    else
                    {
                        _iUIDisplay.WriteLine("Niepoprawna opcja");
                    }
                }
            }

        }

        public void ShowActionInMenu(string Name, List<string> ancestorNameList, List<MenuPosition> menuPositionList)
        {
            if (!ancestorNameList.Contains(Name))
            {
                ancestorNameList.Add(Name);
            }

            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(ancestorNameList);
            _iUIDisplay.WriteLine("\nWybierz opcję:");

            int counter = 1;

            foreach (var position in menuPositionList)
            {
                _iUIDisplay.WriteLine($"[{counter}] {position.Name}");
                counter++;
            }
            _iUIDisplay.WriteLine($"[{exitFromMenu}] Wyjście");

        }

    }


}
