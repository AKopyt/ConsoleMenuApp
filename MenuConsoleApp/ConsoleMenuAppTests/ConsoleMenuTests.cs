using FluentAssertions;
using MenuConsoleApp.Helpers;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Models;
using MenuConsoleApp.UI;
using Moq;
using NSubstitute;


namespace ConsoleMenuAppTests;

public class ConsoleMenuTests
{
    [Fact]
    public void CountAmountOfPagesTest()
    {
        //arrange
        const int pageSize = 10;
        PageCalculator pageCalculator = new PageCalculator();

        var book1 = NSubstitute.Substitute.For<Book>();
        var book2 = NSubstitute.Substitute.For<Book>();
        var book3 = NSubstitute.Substitute.For<Book>();
        var book4 = NSubstitute.Substitute.For<Book>();
        var book5 = NSubstitute.Substitute.For<Book>();
        var book6 = NSubstitute.Substitute.For<Book>();
        
        var movie1 = NSubstitute.Substitute.For<Movie>();
        var movie2 = NSubstitute.Substitute.For<Movie>();
        var movie3 = NSubstitute.Substitute.For<Movie>();
        var movie4 = NSubstitute.Substitute.For<Movie>();
        var movie5 = NSubstitute.Substitute.For<Movie>();
        var movie6 = NSubstitute.Substitute.For<Movie>();
        
        List<CommonItemModel> listOf3Elements = new List<CommonItemModel>() { book1, movie1, movie2 };
        List<CommonItemModel> listOf10Elements = new List<CommonItemModel>() { book1, movie1, movie2, movie3, movie4, movie5, movie6, book2, book3, book4 };
        List<CommonItemModel> listOf12Elements = new List<CommonItemModel>() { book1, movie1, movie2, movie3, movie4, movie5, movie6, book2, book3, book4, book5, book6 };
        List<CommonItemModel> emptyList = new List<CommonItemModel>() {};

        //act
        var resultListOf3Elements = pageCalculator.CountAmountOfPages(listOf3Elements, pageSize);
        var resultListOf10Elements = pageCalculator.CountAmountOfPages(listOf10Elements, pageSize);
        var resultListOf12Elements = pageCalculator.CountAmountOfPages(listOf12Elements, pageSize);
        var resultEmptyList = pageCalculator.CountAmountOfPages(emptyList, pageSize);

        //asssert
        resultListOf3Elements.Should().Be(1);
        resultListOf10Elements.Should().Be(1);
        resultListOf12Elements.Should().Be(2);
        resultEmptyList.Should().Be(1);

    }

    [Theory]
    [InlineData("test", false)]
    [InlineData("Pan", true)]
    [InlineData("1834", true)]
    [InlineData("bajka", false)]
    [InlineData("1543", false)]
    public void ContainTextInBookTest(string userInput, bool expectedResult)
    {
        //arrange
        Book book = new Book()
        {
            Author = "Mickiewicz",
            Title = "Pan Tadeusz",
            Genre = "Epicki wiersz",
            PublicationDate = new DateTime(1834,06,28) ,
            ElementId = 1
        };

        //act
        var result = book.ContainsText(userInput);

        //assert
        Assert.Equal(expectedResult, result);

    }

    [Theory]
    [InlineData("Matrix", true)]
    [InlineData("bajka", false)]
    [InlineData("1999", true)]
    [InlineData("2010", false)]
    [InlineData("Lana", true)]
    public void ContainTextInMovieTest(string userInput, bool expectedResult)
    {
        //arrange
        Movie movie = new Movie()
        {
            Director = "Lana Wachowski, Lilly Wachowski",
            Title = "Matrix",
            Genre = "Akcja",
            PremiereDate = new DateTime(1999, 08, 13),
            ElementId = 2
        };

        //act
        var result = movie.ContainsText(userInput);

        //assert
        Assert.Equal(expectedResult, result);

    }

    [Fact]
    public void FindElementPositiveScenarioTest()
    {
        //arrange
        var consoleUIDisplay = NSubstitute.Substitute.For<IUIDisplay>();
        var consoleUIInput = NSubstitute.Substitute.For<IUIInput>();

        consoleUIInput.ReadLine().Returns("Mickiewicz");
        
        IDSearcher iDSearcher = new IDSearcher(consoleUIDisplay, consoleUIInput);
        
        Book book = new Book()
        {
            Author = "Mickiewicz",
            Title = "Pan Tadeusz",
            Genre = "Epicki wiersz",
            PublicationDate = new DateTime(1834, 06, 28),
            ElementId = 1
        };
       
        List<CommonItemModel> listOfElements = new List<CommonItemModel>() {book};
        
        //act
        var result = iDSearcher.FindElement(listOfElements);

        //assert
        result.Should().Be(true);

    }

    [Fact]
    public void FindElementNegativeScenarioTest()
    {
        //arrange
        var consoleUIDisplay = NSubstitute.Substitute.For<IUIDisplay>();
        var consoleUIInput = NSubstitute.Substitute.For<IUIInput>();

        consoleUIInput.ReadLine().Returns("poemat");

        IDSearcher iDSearcher = new IDSearcher(consoleUIDisplay, consoleUIInput);

        Book book = new Book()
        {
            Author = "Mickiewicz",
            Title = "Pan Tadeusz",
            Genre = "Epicki wiersz",
            PublicationDate = new DateTime(1834, 06, 28)
        };

        List<CommonItemModel> listOfElements = new List<CommonItemModel>() {book};

        //act
        var result = iDSearcher.FindElement(listOfElements);

        //assert
        result.Should().Be(false);

    }
}


