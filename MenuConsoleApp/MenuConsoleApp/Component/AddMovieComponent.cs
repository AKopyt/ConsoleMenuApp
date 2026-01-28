using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using System.Globalization;



namespace MenuConsoleApp.Component
{
    public class AddMovieComponent : CommonItemComponent, IUIComponent
    {
        public string Name { get; set; }
        private readonly IDatabase _database;
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;
        public AddMovieComponent(IDatabase database, IUIDisplay iUIDisplay, IUIInput iUIInput) : base(iUIDisplay, iUIInput)
        {
            Name = "Dodaj film\n";
            _database = database;
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public void Activate(List<string> ancestorNameList)
        {
            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(Name, ancestorNameList);

            Movie movie = new Movie();
            movie.Director = GetDirector();
            movie.PremiereDate = GetPremiereDate();
            movie.Title = GetTitle();
            movie.Genre = GetGenre();
            _database.AddElement(movie);

        }

        public string GetDirector()
        {
            string director = "";
            do
            {
                _iUIDisplay.WriteLine("Podaj reżysera");
                var usertInput = _iUIInput.ReadLine();
                if (!String.IsNullOrEmpty(usertInput))
                {
                    director = usertInput;
                    break;
                }
                else
                {
                    _iUIDisplay.WriteLine("Należy podać wartość");
                }
            }
            while (String.IsNullOrEmpty(director));

            return director;
        }
        
        public DateTime? GetPremiereDate()
        {
            DateTime? date = null;
            do
            {
                _iUIDisplay.WriteLine("Podaj date premiery w formacie dd.MM.yyyy");
                var usertInput = _iUIInput.ReadLine();
                if (!String.IsNullOrEmpty(usertInput))
                {
                    DateTime parsedDate;

                    bool isValidDate = DateTime.TryParseExact(usertInput, "dd.MM.yyyy", new CultureInfo("en-US"),
                        DateTimeStyles.None, out parsedDate);
                    if (isValidDate)
                    {
                        date = parsedDate;
                        break;
                    }
                    else
                    {
                        _iUIDisplay.WriteLine("Wprowadż poprawną datę");
                    }
                }
                else
                {
                    _iUIDisplay.WriteLine("Należy podać wartość");
                }
            }
            while (date == null);

            return date;
        }
    }
}
