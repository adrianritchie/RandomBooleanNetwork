using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Linq;

namespace RandomBooleanNetwork
{

    /// <summary>
    /// Renders output to console
    /// </summary>
    public class OutputRenderer
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public OutputRenderer()
        {
        }

        /// <summary>
        /// Renders results to console
        /// </summary>
        /// <param name="results">Results to be rendered</param>
        public void Render(List<string> results)
        {
            string firstRepeat = null;

            var defaultColor = Console.ForegroundColor;
            var alternateColor = ConsoleColor.Green;
            var consoleColor = defaultColor;

            for (int i = 0; i < results.Count; i++)
            {
                if (
                    (firstRepeat != null && results[i] == firstRepeat)
                     || (firstRepeat == null && i > 0 && results.Take(i - 1).Contains(results[i])))
                {
                    consoleColor = (consoleColor == defaultColor) ? alternateColor : defaultColor;
                    firstRepeat = results[i];
                }
                Console.ForegroundColor = consoleColor;
                Console.WriteLine($"{i,-10} {results[i]}");
            }

            Console.ForegroundColor = defaultColor;
        }

    }
}