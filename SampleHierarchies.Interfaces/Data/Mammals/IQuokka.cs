namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Quokka.
/// </summary>
public interface IQuokka : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Habitat { get; set; }
    public int Weight { get; set; }
    public string SocialBehavior { get; set; }

    #endregion // Interface Members
}
