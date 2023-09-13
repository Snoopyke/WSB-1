using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Antelope's screen.
    /// </summary>
    public sealed class AntelopeScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private readonly IDataService _dataService;
        private readonly SettingsService _settingsService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public AntelopeScreen(IDataService dataService, SettingsService settingsService)
        {
            _dataService = dataService;
            _settingsService = settingsService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                _settingsService.LoadConsoleColor(ScreenEnum.AntelopeScreen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all antelopes");
                Console.WriteLine("2. Create a new antelope");
                Console.WriteLine("3. Delete existing antelope");
                Console.WriteLine("4. Modify existing antelope");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AntelopeScreenChoices choice = (AntelopeScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AntelopeScreenChoices.List:
                            ListAntelope();
                            break;

                        case AntelopeScreenChoices.Create:
                            AddAntelope();
                            break;

                        case AntelopeScreenChoices.Delete:
                            DeleteAntelope();
                            break;

                        case AntelopeScreenChoices.Modify:
                            EditAntelopeMain();
                            break;

                        case AntelopeScreenChoices.Exit:
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

        #region Private Methods

        /// <summary>
        /// List all antelopes.
        /// </summary>
        private void ListAntelope()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Antelopes is not null &&
                _dataService.Animals.Mammals.Antelopes.Count > 0)
            {
                Console.WriteLine("Here's a list of antelopes:");
                int i = 1;
                foreach (Antelope antelope in _dataService.Animals.Mammals.Antelopes)
                {
                    Console.Write($"Antelope number {i}, ");
                    antelope.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of antelopes is empty.");
            }
        }

        /// <summary>
        /// Add an antelope.
        /// </summary>
        private void AddAntelope()
        {
            try
            {
                Antelope antelope = AddEditAntelope();
                _dataService?.Animals?.Mammals?.Antelopes?.Add(antelope);
                Console.WriteLine("Antelope with name: {0} has been added to a list of antelopes", antelope.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes an antelope.
        /// </summary>
        private void DeleteAntelope()
        {
            try
            {
                Console.Write("What is the name of the antelope you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Antelope? antelope = (Antelope?)(_dataService?.Animals?.Mammals?.Antelopes
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (antelope is not null)
                {
                    _dataService?.Animals?.Mammals?.Antelopes?.Remove(antelope);
                    Console.WriteLine("Antelope with name: {0} has been deleted from a list of antelopes", antelope.Name);
                }
                else
                {
                    Console.WriteLine("Antelope not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing antelope after choice made.
        /// </summary>
        private void EditAntelopeMain()
        {
            try
            {
                Console.Write("What is the name of the antelope you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Antelope? antelope = (Antelope?)(_dataService?.Animals?.Mammals?.Antelopes?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (antelope is not null)
                {
                    Antelope antelopeEdited = AddEditAntelope();
                    antelope.Copy(antelopeEdited);
                    Console.Write("Antelope after edit:");
                    antelope.Display();
                }
                else
                {
                    Console.WriteLine("Antelope not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edits specific antelope.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Antelope AddEditAntelope()
        {
            Console.Write("What is the name of the antelope? ");
            string? name = Console.ReadLine();
            Console.Write("What is the antelope's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the antelope's life span? ");
            string? lifeSpanAsString = Console.ReadLine();
            Console.Write("What is the antelope's social structure? ");
            string? socialStructure = Console.ReadLine();
            Console.Write("What is the antelope's diet? ");
            string? diet = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (lifeSpanAsString is null)
            {
                throw new ArgumentNullException(nameof(lifeSpanAsString));
            }
            if (socialStructure is null)
            {
                throw new ArgumentNullException(nameof(socialStructure));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            int age = Int32.Parse(ageAsString);
            int lifeSpan= Int32.Parse(lifeSpanAsString);
            Antelope antelope = new Antelope(name, age, lifeSpan, socialStructure, diet);
            return antelope;
        }

        #endregion // Private Methods
    }
}