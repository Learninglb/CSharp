﻿using System;

namespace SwordDamage
{
    public class ArrowDamage
    {
        private const decimal BASE_MULTIPLIER = .35M;
        private const decimal FLAME_DAMAGE = 1.25M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;

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
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int) Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int) Math.Ceiling(baseDamage);
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