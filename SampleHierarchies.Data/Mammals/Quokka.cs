using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Quokka class.
/// </summary>
public class Quokka : MammalBase, IQuokka
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my habitat is: {Habitat}, my weight is {Weight}, my social behavior is {SocialBehavior}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IQuokka ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Habitat = ad.Habitat;
            Weight = ad.Weight;
            SocialBehavior = ad.SocialBehavior;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Habitat { get; set; }
    public int Weight { get; set; }
    public string SocialBehavior { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name"> Name </param>
    /// <param name="age"> Age </param>
    /// <param name="habitat"> Habitat </param>
    /// <param name="weight"> Weight </param>
    /// <param name="socialBehavior"> SocialBehavior </param>
    public Quokka(string name, int age, string habitat, int weight, string socialBehavior)
    {
        Name = name;
        Age = age;
        Habitat = habitat;
        Weight = weight;
        SocialBehavior = socialBehavior;
    }

    #endregion // Ctors And Properties
}
