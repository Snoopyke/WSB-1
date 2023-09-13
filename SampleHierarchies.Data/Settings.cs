using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings Class
    /// </summary>
    public class Settings : ISettings
    {
        /// <summary>
        /// Properties
        /// </summary>
        public Dictionary<ScreenEnum, ConsoleColor> ConsoleScreensColor { get; set; } = new Dictionary<ScreenEnum, ConsoleColor>();
    }
}
