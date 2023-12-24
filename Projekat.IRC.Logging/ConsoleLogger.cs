using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.Logging
{
    public class ConsoleLogger : ILoggger
    {
        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Information: {message}");
            Console.ResetColor();
        }

        public void LogWarning(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Warning: {message}");
            Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
    }
}
