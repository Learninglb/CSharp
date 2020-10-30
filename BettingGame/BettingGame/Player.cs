﻿using System;
using System.ComponentModel.Design;

namespace BettingGame
{
    public class Player
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// Writes the names and amounts of dollars for each guy.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " dollars.");
        }
        /// <summary>
        /// Gives some of my cash, removing it from my wallet (or printing a message to the console
        /// if I don't have enough cash
        /// </summary>
        /// <param name="amount">Amount of cash to be given.</param>
        /// <returns>The amount of cash removed from my wallet, or 0 if i don't have
        /// enough cash (or if the amount is invalid).
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + "says: " + amount + " isn't valid amount");
                return 0;
            }

            if (amount > Cash)
            {
                Console.WriteLine(Name + "says:" + "I don't have enough cash to give you " + amount);
                return  0;
            }

            Cash -= amount;
            return amount;
        }

        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take.");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}