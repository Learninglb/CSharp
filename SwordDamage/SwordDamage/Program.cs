using System;
using System.Net;

namespace SwordDamage
{
    class Program
    {
        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage();
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("Enter 0 for no magic/flaming, 1 for magic, 2 for flaming, " +
                                  "3 for both, and anything else to quit.");
                char key = Console.ReadKey().KeyChar;
                if (key != '0' && key != '1' && key != '2' && key != '3') return;
                int roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);

                swordDamage.Roll = roll;
                swordDamage.SetMagic(key == '1' || key == '3');
                swordDamage.SetFlaming(key == '2' || key == '3');
                Console.WriteLine("\nRolled " + roll + " for " + swordDamage.Damage + " HP\n");
            } 
            
        }
    }
}