using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IAntelope> Antelopes { get; set; }
    public List<IWhale> Whales { get; set; }
    public List<IQuokka> Quokkas { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Antelopes = new List<IAntelope>();
        Whales = new List<IWhale>();
        Quokkas = new List<IQuokka>();
    }

    #endregion // Ctors
}
