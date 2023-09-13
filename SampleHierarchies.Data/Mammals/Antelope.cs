using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Antelope class.
/// </summary>
public class Antelope : MammalBase, IAntelope
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my species is {Lifespan}, my social structure is {SocialStructure}, my diet is {Diet} ");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IAntelope ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            SocialStructure = ad.SocialStructure;
            Lifespan = ad.Lifespan;
            Diet = ad.Diet;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public int Lifespan { get; set; }
    public string SocialStructure { get; set; }
    public string Diet { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="lifespan">Species</param>
    /// <param name="name">Name</param>
    /// <param name="socialStructure">SocialStructure</param>
    /// <param name="diet ">Diet</param>
    public Antelope(string name, int age, int lifespan, string socialStructure, string diet)
    {
        Name = name;
        Age = age;
        Lifespan = lifespan;
        SocialStructure = socialStructure;
        Diet = diet;
    }

    #endregion // Ctors And Properties
}
