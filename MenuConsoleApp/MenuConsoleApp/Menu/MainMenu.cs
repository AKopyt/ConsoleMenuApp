using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Component;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Menu
{
    public class MainMenu : UIMenu
    {
        public override string Name => "Menu główne";
        protected override List<MenuPosition> MenuPositionList { get; set; }
        
        private readonly IDatabase _database;
        private readonly IUIDisplay _iUiDisplay;
        private readonly IUIInput _iUIInput;

        public MainMenu(IDatabase database, IUIDisplay iUIDisplay, IUIInput iUIInput ) : base(iUIDisplay, iUIInput)
        {
            _database=database;
            _iUiDisplay = iUIDisplay;
            _iUIInput = iUIInput; 

            MenuPositionList = new List<MenuPosition>()
            {
                new MenuPosition() { Name = "Dodaj książkę", Component = new AddBookComponent(_database, _iUiDisplay, _iUIInput)},
                new MenuPosition() { Name = "Dodaj film", Component = new AddMovieComponent(_database, _iUiDisplay, _iUIInput)},
                new MenuPosition() { Name = "Usuń książkę lub film", Component = new DeleteElementComponent(_database, _iUiDisplay, _iUIInput)},
                new MenuPosition() { Name = "Wyświetl szczegóły pojedyńczej pozycji", Component = new DisplaySingleElementComponent(_database, _iUiDisplay, _iUIInput)},
                new MenuPosition() { Name = "Wyświetl wszystkie pozycje", Component = new DisplayElementsOnPageComponent(_database,1,10,_iUiDisplay, _iUIInput)},

            };
        }
    }
}

