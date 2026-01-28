
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Component
{
    public abstract class CommonItemComponent
    {
        private readonly IUIDisplay _iUIDisplay;
        private readonly IUIInput _iUIInput;
        public CommonItemComponent(IUIDisplay iUIDisplay, IUIInput iUIInput)
        {
            _iUIDisplay = iUIDisplay;
            _iUIInput = iUIInput;
        }
        public string GetTitle()
        {
            string title = "";
            do
            {
                _iUIDisplay.WriteLine("Podaj tytuł");
                var usertInput = _iUIInput.ReadLine();
                if (!string.IsNullOrEmpty(usertInput))
                {
                    title = usertInput;
                    break;
                }
                else
                {
                    _iUIDisplay.WriteLine("Należy podać wartość");
                }
            }
            while (string.IsNullOrEmpty(title));
            return title;
        }

        public string GetGenre()
        {
            string genre = "";
            do
            {
                _iUIDisplay.WriteLine("Podaj gatunek");
                var userInput = _iUIInput.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    genre = userInput;
                    break;
                }
                else
                {
                    _iUIDisplay.WriteLine("Należy podać wartość");
                }
            }
            while (string.IsNullOrEmpty(genre));
            return genre;
        }
    }
}
