using System.Diagnostics;
 namespace DamageCalculator
 {
    public class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;


        public int Damage { get; private set;}

        private int roll;

        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        public void CalculateDamage()
        {
            decimal MagicMultiplier = 1M;
            if (Magic) MagicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int) (Roll * MagicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
        private bool magic;
        
        public bool Magic
        {
            get { return magic;}
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private bool flaming;
        
        public bool Flaming
        {
            get { return flaming;}
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }
    }
}