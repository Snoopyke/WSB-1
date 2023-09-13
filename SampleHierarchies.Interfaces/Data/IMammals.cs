using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Animals collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    List<IAntelope> Antelopes { get; set; }
    List<IWhale> Whales { get; set; }
    List<IQuokka> Quokkas { get; set; }

    #endregion // Interface Members
}
