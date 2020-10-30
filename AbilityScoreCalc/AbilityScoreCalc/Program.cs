using System;

namespace AbilityScoreCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                calculator.Roll = ReadInt(calculator.Roll, "Starting 4d6 roll" );
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score, 
                    Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }
        /// <summary>
        /// Writes a prompt and reads an value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value.</param>
        /// <param name="prompt">Prompt to print to the console.</param>
        /// <returns>The value read, or the default value if unable to parse</returns>
        static int ReadInt(int lastUsedValue, string prompt)
        { 
            // Write the prompt followed by [default value]:
            // Read the line from the input and try to parse it
            // If it can be parsed, write " using value" + value to the console
            // Otherwise write " using default value" + lastUsedValue to the console
            Console.WriteLine(prompt + " [ " + lastUsedValue + "]; ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine("  using value " + value, Console.ForegroundColor = ConsoleColor.Black);
                return value;
            }
            else
            {
                Console.WriteLine("  using default value " + lastUsedValue, Console.ForegroundColor = ConsoleColor.Black);
                return lastUsedValue;
            }
        }
        static double ReadDouble(double lastUsedValue, string prompt)
        { 
            // Write the prompt followed by [default value]:
            // Read the line from the input and try to parse it
            // If it can be parsed, write " using value" + value to the console
            // Otherwise write " using default value" + lastUsedValue to the console
            Console.WriteLine(prompt + " [ " + lastUsedValue + "]; ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine("  using value " + value, Console.ForegroundColor = ConsoleColor.Black);
                return value;
            }
            else
            {
                Console.WriteLine("  using default value" + lastUsedValue, Console.ForegroundColor = ConsoleColor.Black);
                return lastUsedValue;
            }
        }
    }
}