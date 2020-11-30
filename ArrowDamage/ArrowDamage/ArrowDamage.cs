using System;

namespace ArrowDamage
{
    public class ArrowDamage
    {
        private const decimal BASE_MULTIPLIER = .35M;
        private const decimal FLAME_DAMAGE = 1.25M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (isMagic) baseDamage *= MagicMultiplier;
            if (isFlaming) Damage = (int) Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int) Math.Ceiling(baseDamage);
        }

        public void SetMagic(bool isMagic)
        {
            MagicMultiplier = isMagic ? 1.75M : 1M;
            CalculateDamage();
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }
    }
}