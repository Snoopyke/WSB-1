namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Whale.
/// </summary>
public interface IWhale : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Reproduction { get; set; }
    public string Sound { get; set; }
    public string MigrationPatterns { get; set; }

    #endregion // Interface Members
}
