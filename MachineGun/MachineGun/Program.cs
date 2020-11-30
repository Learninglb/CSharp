using System;

namespace MachineGun
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBullets = ReadInt(20, "Number of Bullets");
            int magazineSize = ReadInt(16, "Magazine size");

            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);
            
            MachineGun gun = new MachineGun( numberOfBullets, magazineSize, isLoaded);
            while (true)
            {
               Console.WriteLine($"{gun.Bullets} bullets, {gun.BulletsLoaded} loaded");
               if (gun.IsEmpty()) Console.WriteLine("Warning:  You're out of ammo");
               Console.WriteLine("Space to shoot, r to reload, a to add ammo, q to quit");
               Console.WriteLine("");
               char key = Console.ReadKey(true).KeyChar;
               if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
               else if (key == 'r') gun.Reload();
               else if (key == 'a') gun.Bullets += gun.MagazineSize;
               else if (key == 'q') return;
            }
                   
        }
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
    }
}