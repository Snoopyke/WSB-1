using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Quokka's screen.
    /// </summary>
    public sealed class QuokkaScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;
        private SettingsService _settingsService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public QuokkaScreen(IDataService dataService, SettingsService settingsService)
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
                _settingsService.LoadConsoleColor(ScreenEnum.QuokkaScreen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all quokkas");
                Console.WriteLine("2. Create a new quokka");
                Console.WriteLine("3. Delete existing quokka");
                Console.WriteLine("4. Modify existing quokka");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    QuokkaScreenChoices choice = (QuokkaScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case QuokkaScreenChoices.List:
                            ListQuokka();
                            break;

                        case QuokkaScreenChoices.Create:
                            AddQuokka();
                            break;

                        case QuokkaScreenChoices.Delete:
                            DeleteQuokka();
                            break;

                        case QuokkaScreenChoices.Modify:
                            EditQuokkaMain();
                            break;

                        case QuokkaScreenChoices.Exit:
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
        /// List all quokka's.
        /// </summary>
        private void ListQuokka()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Quokkas is not null &&
                _dataService.Animals.Mammals.Quokkas.Count > 0)
            {
                Console.WriteLine("Here's a list of quokkas:");
                int i = 1;
                foreach (Quokka quokka in _dataService.Animals.Mammals.Quokkas)
                {
                    Console.Write($"Quokka number {i}, ");
                    quokka.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of quokkas is empty.");
            }
        }

        /// <summary>
        /// Add a quokka.
        /// </summary>
        private void AddQuokka()
        {
            try
            {
                Quokka quokka = AddEditQuokka();
                _dataService?.Animals?.Mammals?.Quokkas?.Add(quokka);
                Console.WriteLine("Quokka with name: {0} has been added to a list of quokkas", quokka.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a quokka.
        /// </summary>
        private void DeleteQuokka()
        {
            try
            {
                Console.Write("What is the name of the quokka you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Quokka? quokka = (Quokka?)(_dataService?.Animals?.Mammals?.Quokkas
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (quokka is not null)
                {
                    _dataService?.Animals?.Mammals?.Quokkas?.Remove(quokka);
                    Console.WriteLine("Quokka with name: {0} has been deleted from a list of quokkas", quokka.Name);
                }
                else
                {
                    Console.WriteLine("Quokka not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing quokka after choice made.
        /// </summary>
        private void EditQuokkaMain()
        {
            try
            {
                Console.Write("What is the name of the quokka you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Quokka? quokka = (Quokka?)(_dataService?.Animals?.Mammals?.Quokkas?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (quokka is not null)
                {
                    Quokka quokkaEdited = AddEditQuokka();
                    quokka.Copy(quokkaEdited);
                    Console.Write("Quokka after edit:");
                    quokka.Display();
                }
                else
                {
                    Console.WriteLine("Quokka not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific quokka.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Quokka AddEditQuokka()
        {
            Console.Write("What name of the quokka? ");
            string? name = Console.ReadLine();
            Console.Write("What is the quokka's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the quokka's habitat? ");
            string? habitat = Console.ReadLine();
            Console.Write("What is the quokka's weight? ");
            string? weightAsString = Console.ReadLine();
            Console.Write("What is the quokka's social behavior? ");
            string? socialBehavior = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (habitat is null)
            {
                throw new ArgumentNullException(nameof(habitat));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (socialBehavior is null)
            {
                throw new ArgumentNullException(nameof(socialBehavior));
            }
            int age = int.Parse(ageAsString);
            int weight = int.Parse(weightAsString);

            Quokka quokka = new Quokka(name, age, habitat, weight, socialBehavior);
            return quokka;
        }

        #endregion // Private Methods
    }
}
