using System;

namespace MyLinqF1.Utils
{
    public static class ConsoleHelper
    {
        public static int PromptInt(string message, int min, int max)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value)
                     || value < min || value > max);
            return value;
        }

        public static string PromptString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        public static void Pause()
        {
            Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
            Console.ReadLine();
        }
    }
}