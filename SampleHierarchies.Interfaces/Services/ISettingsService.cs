using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{
    #region Interface Members
    public ISettings? Read(string jsonPath);
    public void Write(ISettings settings, string jsonPath);
    public void LoadConsoleColor(ScreenEnum screenEnum);
    public void EditConsoleColor(ScreenEnum screensEnum, ConsoleColor consoleColor);

    #endregion // Interface Members
}
