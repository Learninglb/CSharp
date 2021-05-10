using System;


namespace Birds
{
    abstract class Bird
    {
        public static Random Randomizer = new Random();
        public abstract Egg[] LayEggs(int numberOfEggs);

    }
    
    class Pigeon : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(4) == 0)
                    eggs[i] = new BrokenEgg ("white");
                else
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 2, "white");
            }
            return eggs;
        }
    }
    

    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12 , "speckled");
            }
            return eggs;
        }
    }
}