namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Antelope.
/// </summary>
public interface IAntelope : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public int Lifespan { get; set; }
    public string SocialStructure { get; set; }
    public string Diet { get; set; }

    #endregion // Interface Members
}
