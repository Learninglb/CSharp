using System;


namespace HiLoGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HiLo.");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}.");
            HiLoGame.Hint();
            while (HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press H for higher, L for lower, Z to buy a hint,");
                Console.WriteLine($"or any other key to quit, your balance is ${HiLoGame.GetPot()}.");
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'H') HiLoGame.Guess(true);
                else if (key == 'L') HiLoGame.Guess(false);
                else if (key == 'Z') HiLoGame.Hint();
                else return;
            }
            Console.WriteLine("The pot is empty. Bye!");
        }
    }
}