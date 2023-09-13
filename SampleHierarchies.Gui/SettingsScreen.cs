using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Data;

namespace SampleHierarchies.Gui;

/// <summary>
/// Settings screen class.
/// </summary>
public sealed class SettingsScreen : Screen
{

    #region Properties And Ctor

    public SettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public SettingsScreen(SettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.LoadConsoleColor(ScreenEnum.SettingsScreen);
            Console.WriteLine("Your available displays: ");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Main Screen");
            Console.WriteLine("2. Animal Screen");
            Console.WriteLine("3. Mammal Screen");
            Console.WriteLine("4. Dog Screen");
            Console.WriteLine("5. Antelope Screen");
            Console.WriteLine("6. Quokka Screen");
            Console.WriteLine("7. Whale Screen");
            Console.WriteLine("8. Settings Screen");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate user choice
            try
            {
                if (choiceAsString == null) throw new ArgumentNullException();

                int choice = int.Parse(choiceAsString);

                if (choice >= 1 && choice <= 8) SetConsoleColors((ScreenEnum) choice);
                else if(choice == 0) { return; } 
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    // used to set console colors in json
    private void SetConsoleColors(ScreenEnum screen)
    {
        try
        {
            Console.Write("Write new color for display: ");
            string? colorsAsString = Console.ReadLine();
            if (colorsAsString == null) throw new ArgumentNullException();
            ConsoleColor newScreenColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorsAsString); // parsing console color
            _settingsService.EditConsoleColor(screen, newScreenColor);
        }
        catch
        {
            Console.WriteLine("Invalid Input. Try again.");
        }
    }

    #endregion // Private Methods
}