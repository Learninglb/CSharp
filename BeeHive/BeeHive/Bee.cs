using System;

namespace BeeHive
{
    public class Bee
    {
        public virtual float CostPerShift { get; }
        public string Job { get; private set; }

        public Bee(string job)
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        protected virtual void DoJob(){/*the subclass overrides this*/}
    }
    
    public class Queen: Bee
    {
        // constructors
        private const float EGGS_PER_SHIFT = .45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = .5f;
        
        // variables
        private float eggs = 0;
        private float unassignedWorkers = 3;
        private Bee[] workers = new Bee[0];
        
        public string StatusReport { get; private set; }

        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }
        
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }
        
        public void AssignBee(string job)
        {
            switch (job)

            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
            }
            
            UpdateStatusReport();
        }
        
        public override float CostPerShift => 2.1f;
        
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
                           $"\nEgg Count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
                           $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
                           $"\n{WorkerStatus("Egg Care")}\nTotal Workers: {workers.Length}";
        }

        public void CareForEggs(float eggsToconvert)
        {
            if (eggs >= eggsToconvert)
            {
                eggs -= eggsToconvert;
                unassignedWorkers += eggsToconvert;
            }
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job)
                    count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }
        
        
    }
    
    public class NectarCollector : Bee
    {
        // constructor
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        public override float CostPerShift => 1.95f;
        public NectarCollector() : base("Nectar Collector"){}

        protected override void DoJob()
        {
            HoneyVault.ConsumeHoney(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
    
    public class HoneyManufacturer : Bee
    {
        // constructor
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        public override float CostPerShift => 1.7f;
        public HoneyManufacturer() : base("Honey Manufacturer"){}
        
        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
            
    }
    
    class EggCare : Bee
    {
        // constructor
        private const float CARE_PROGRESS_PER_SHIFT = .15f;

        public override float CostPerShift
        {
            get { return 1.35f; }
        }

        private Queen queen;

        public EggCare(Queen queen) : base("Egg Care")
        {
            this.queen = queen;
        }
        
        protected override void DoJob()
        { 
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
            
    }
}
