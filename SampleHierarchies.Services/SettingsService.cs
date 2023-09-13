using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using System.Diagnostics;
using System.Text.Json;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
/// 
public class SettingsService
{
    #region ISettings Implementation

    /// <inheritdoc/>
    /// Used to read data from json
    public ISettings? Read(string jsonPath)
    {
        try
        {
            if (!File.Exists("SavedColors.json")) { Console.WriteLine("SavedColors.json not found"); }
            if (jsonPath is null) throw new ArgumentNullException();
            string? jsonSource = File.ReadAllText(jsonPath);
            var jsonContent =  JsonSerializer.Deserialize<Settings>(jsonSource);
            if (jsonContent == null) throw new ArgumentNullException();
            return jsonContent;
        }
        catch
        {
            Console.WriteLine("Data reading was not successful.");
            return new Settings();
        }
    }

    /// <inheritdoc/>
    /// Used to write data to json
    public void Write(ISettings settings, string? jsonPath)
    {
        try
        {
            if (jsonPath is null) throw new ArgumentNullException();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(settings));  // saving data
            Console.WriteLine("Data saving to: '{0}' was successful.", jsonPath);
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }
    /// Used to read and update data from json
    public void LoadConsoleColor(ScreenEnum screenEnum)
    {
        try
        {
            ISettings? Settings;
            Settings = Read("SavedColors.json"); // read data
            Console.ForegroundColor = Settings?.ConsoleScreensColor[screenEnum] ?? ConsoleColor.White; 
        }
        catch
        {
            Console.ResetColor();
            Console.WriteLine("Data reading from json was not successful.");
        }
    }
    /// Used to edit json data
    public void EditConsoleColor(ScreenEnum screensEnum, ConsoleColor newConsoleColor)
    {
        ISettings? settings;
        settings = Read("SavedColors.json"); // read data
        if (settings != null) settings.ConsoleScreensColor[screensEnum] = newConsoleColor; 
        else settings = new Settings();
        Write(settings, "SavedColors.json"); // update data in json
    }

    #endregion // ISettings Implementation
}