using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Whale's screen.
    /// </summary>
    public sealed class WhaleScreen : Screen
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
        public WhaleScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.LoadConsoleColor(ScreenEnum.WhaleScreen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all whales");
                Console.WriteLine("2. Create a new whale");
                Console.WriteLine("3. Delete existing whale");
                Console.WriteLine("4. Modify existing whale");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    WhaleScreenChoices choice = (WhaleScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case WhaleScreenChoices.List:
                            ListWhale();
                            break;

                        case WhaleScreenChoices.Create:
                            AddWhale();
                            break;

                        case WhaleScreenChoices.Delete:
                            DeleteWhale();
                            break;

                        case WhaleScreenChoices.Modify:
                            EditWhaleMain();
                            break;

                        case WhaleScreenChoices.Exit:
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
        /// List all whale's.
        /// </summary>
        private void ListWhale()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Whales is not null &&
                _dataService.Animals.Mammals.Whales.Count > 0)
            {
                Console.WriteLine("Here's a list of whales:");
                int i = 1;
                foreach (Whale whale in _dataService.Animals.Mammals.Whales)
                {
                    Console.Write($"Whale number {i}, ");
                    whale.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of whales is empty.");
            }
        }

        /// <summary>
        /// Add a whale.
        /// </summary>
        private void AddWhale()
        {
            try
            {
                Whale whale = AddEditWhale();
                _dataService?.Animals?.Mammals?.Whales?.Add(whale);
                Console.WriteLine("Whale with name: {0} has been added to a list of whales", whale.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a whale.
        /// </summary>
        private void DeleteWhale()
        {
            try
            {
                Console.Write("What is the name of the whale you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Whale? whale = (Whale?)(_dataService?.Animals?.Mammals?.Whales
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (whale is not null)
                {
                    _dataService?.Animals?.Mammals?.Whales?.Remove(whale);
                    Console.WriteLine("Whale with name: {0} has been deleted from a list of whales", whale.Name);
                }
                else
                {
                    Console.WriteLine("Whale not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing whale after choice made.
        /// </summary>
        private void EditWhaleMain()
        {
            try
            {
                Console.Write("What is the name of the whale you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Whale? whale = (Whale?)(_dataService?.Animals?.Mammals?.Whales?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (whale is not null)
                {
                    Whale whaleEdited = AddEditWhale();
                    whale.Copy(whaleEdited);
                    Console.Write("Whale after edit:");
                    whale.Display();
                }
                else
                {
                    Console.WriteLine("Whale not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific whale.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Whale AddEditWhale()
        {
            Console.Write("What name of the whale? ");
            string? name = Console.ReadLine();
            Console.Write("What is the whale's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the whale's reproduction? ");
            string? reproduction = Console.ReadLine();
            Console.Write("What is the whale's sound? ");
            string? sound = Console.ReadLine();
            Console.Write("What is the whale's migration patterns? ");
            string? migrationPatterns = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (reproduction is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (sound is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            if (migrationPatterns is null)
            {
                throw new ArgumentNullException(nameof(migrationPatterns));
            }
            int age = Int32.Parse(ageAsString);
            Whale whale = new Whale(name, age, reproduction, sound, migrationPatterns);
            return whale;
        }

        #endregion // Private Methods
    }
}
