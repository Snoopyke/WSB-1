using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly DogsScreen _dogsScreen;
    private readonly AntelopeScreen _antelopeScreen;
    private readonly WhaleScreen _whaleScreen;
    private readonly QuokkaScreen _qokkaScreen;
    private readonly SettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AntelopeScreen antelopeScreen, WhaleScreen whaleScreen, SettingsService settingsService, QuokkaScreen qokkaScreen)
    {
        _settingsService = settingsService;
        _dogsScreen = dogsScreen;
        _antelopeScreen = antelopeScreen;
        _whaleScreen = whaleScreen;
        _qokkaScreen = qokkaScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.LoadConsoleColor(ScreenEnum.MammalScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Antelopes");
            Console.WriteLine("3. Qokkas");
            Console.WriteLine("4. Whales");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show(); break;
                    case MammalsScreenChoices.Antelope:
                        _antelopeScreen.Show(); break;
                    case MammalsScreenChoices.Quokka:
                        _qokkaScreen.Show(); break;
                    case MammalsScreenChoices.Whale:
                        _whaleScreen.Show(); break;
                    case MammalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods
}
