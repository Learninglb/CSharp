using System;
using System.Runtime.CompilerServices;


namespace BettingGame
{
    class Program
    {



        static void Main(string[] args)
        {
            var odds = (double) .75;
            Random random = new Random();
            
            Player player = new Player {Cash = 100, Name = "The player"};

            //Welcome the player and print the odds
            Console.WriteLine("Welcome to the casino to play double or nothing.");
            Console.WriteLine("The odds are .{0}", odds);

            while (player.Cash > 0)
            {
                player.WriteMyInfo();
            
                //Ask the player how much money they want to bet
                Console.WriteLine("Enter an amount to double or lose: ");

                //Read the bet into a string called howmuch
                string howmuch = Console.ReadLine();

                //Try to parse into an int variable called amount
                if (int.TryParse(howmuch, out int amount))
                {
                    //If it parses, the player gives the amount to an int variable called pot.
                    //It gets multiplied by two, because it’s a double-or-nothing bet.
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {

                            //The program picks a random number between 0 and 1.

                        //If the number is greater than odds, the player receives the pot.
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win {0}", winnings);
                            player.ReceiveCash(winnings);
                        }
                        //If not, the player loses.
                        else
                        {
                            Console.WriteLine("You lose.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
            }
            Console.WriteLine("The house always wins.");
        }
    }
}
