using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using MenuConsoleApp.Database;
using MenuConsoleApp.Interfaces;
using MenuConsoleApp.Menu;
using MenuConsoleApp.Models;
using MenuConsoleApp.UI;
using Microsoft.Extensions.Configuration;

namespace MenuConsoleApp;

class Program
{

    public static void Main(string[] args)
    {
        try
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var pathToFile = (config.GetSection("pathToFile").Value);

            ConsoleUIDisplay consoleUIDisplay = new ConsoleUIDisplay();
            ConsoleUIInput consoleUIInput = new ConsoleUIInput();
            DatabaseFileStorage databaseFileStorage = new DatabaseFileStorage();

            if (pathToFile != null)
            {
                try
                {
                    IDatabase database = databaseFileStorage.ReadDatabase(pathToFile);
                    MainMenu mainMenu = new MainMenu(database, consoleUIDisplay, consoleUIInput);

                    mainMenu.Activate(new List<string>());

                    databaseFileStorage.SaveDatabase(database, pathToFile);
                }
                catch (FileNotFoundException e)
                {
                    consoleUIDisplay.WriteLine($"Nie znaleziono pliku pod ścieżką: {pathToFile}");
                    consoleUIDisplay.WriteLine("Naciśnij przycisk, aby zakończyć");
                    consoleUIInput.ReadLine();

                }

            }
            else
            {
                consoleUIDisplay.WriteLine("Plik z bazą danych nie istnieje");
                consoleUIInput.ReadLine();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Wystąpił błąd");
        }

    }
}