namespace MachineGun
{
    public class MachineGun
    {
        // This is a constructor of the same name as the class
        public MachineGun(int bullets, int magazineSize, bool loaded)
        {
            this.bullets = bullets;
            MagazineSize = magazineSize;
            if (!loaded) Reload();
        }
        
        // MagazineSize is a property
        public int MagazineSize { get; private set; } = 16;

        private int bullets = 0;

        // Bullets is a property
        public int Bullets
        {
            get { return this.bullets; }
            set
            {
                if (value > 0)
                    this.bullets = value;
                Reload();
            }
        }
        
        // IsEmpty is a Method
        public bool IsEmpty() { return BulletsLoaded == 0; }
        
        // BulletsLoaded is a property
        public int BulletsLoaded { get; private set; }
        
        // Reload is a method
        public void Reload()
        {
            if (this.bullets > MagazineSize)
                BulletsLoaded = MagazineSize;
            else
                BulletsLoaded = bullets;
        }

        // Shoot is a method
        public bool Shoot()
        {
            if (BulletsLoaded == 0) return false;
            BulletsLoaded--;
            this.bullets--;
            return true;
            
        }
    }
}