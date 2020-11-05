using System.Diagnostics;
 namespace DamageCalculator
 {
    public class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int) (Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll}");
        }

        public void SetMagic(bool isMagic)
        {
            MagicMultiplier = isMagic ? 1.75M : 1M;
            CalculateDamage();
            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlaming finished: {Damage} (roll: {Roll})");
        }
    }
}