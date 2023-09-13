using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Whale class.
/// </summary>
public class Whale : MammalBase, IWhale
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am barking", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my reproduction is: {Reproduction}, my sound is {Sound}, my migration patterns is {MigrationPatterns}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IWhale ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Reproduction = ad.Reproduction;
            Sound = ad.Sound;
            MigrationPatterns = ad.MigrationPatterns;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Reproduction { get; set; }
    public string Sound { get; set; }
    public string MigrationPatterns { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="reproduction">Reproduction</param>
    /// <param name="sound">Sound</param>
    /// <param name="migrationPatterns">MigrationPatterns</param>
    public Whale(string name, int age, string reproduction, string sound, string migrationPatterns)
    {
        Name = name;
        Age = age;
        Reproduction = reproduction;
        Sound = sound;
        MigrationPatterns = migrationPatterns;
    }

    #endregion // Ctors And Properties
}
