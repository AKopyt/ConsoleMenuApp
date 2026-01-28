using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using System.Globalization;

namespace MenuConsoleApp.Component
{
    public class AddBookComponent : CommonItemComponent, IUIComponent
    {
        public string Name { get; set; }
     
        private readonly IDatabase _database;
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;

        public AddBookComponent(IDatabase database, IUIDisplay iUIDisplay, IUIInput iUIInput) : base(iUIDisplay, iUIInput)
        {
            Name = "Dodaj książke\n";
            _database = database;
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public void Activate(List<string> ancestorNameList)
        {
            NamePath namePath = new NamePath(_iUIDisplay);
            namePath.ShowNamePath(Name,ancestorNameList);
           
            Book book = new Book();
            book.Author = GetAuthor();
            book.PublicationDate = GetPublicationDate();
            book.Title = GetTitle();
            book.Genre = GetGenre();
            _database.AddElement(book);
            

        }
        public string GetAuthor()
        {
            string author = "";
            do
            {
                _iUIDisplay.WriteLine("Podaj autora");
                var usertInput = _iUIInput.ReadLine();
                if (!String.IsNullOrEmpty(usertInput))
                {
                    author = usertInput;
                    break;
                }
                else
                {
                    _iUIDisplay.WriteLine("Należy podać wartość");
                }
            }
            while (String.IsNullOrEmpty(author));

            return author;
        }
        public DateTime? GetPublicationDate()
        {
            DateTime? date = null;
            do
            {
                _iUIDisplay.WriteLine("Podaj date publikacji w formacie dd.MM.yyyy");
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
