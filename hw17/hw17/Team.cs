namespace BuildingHouse
{
    public class Team(Worker[] workers, TeamLeader teamLeader, House house)
    {
        private readonly Worker[] workers = workers;
        private readonly TeamLeader teamLeader = teamLeader;
        private readonly House house = house;

        public void BeginConstruction()
        {
            bool isComp = false;

            while (!isComp)
            {
                foreach (var worker in workers)
                {
                    worker.Work(house);
                }
                teamLeader.Work(house);

                isComp = IsConstructionComplete();
            }
        }
        private bool IsConstructionComplete()
        {
            bool basementBuilt = house.Basement.IsBuilt;
            bool doorBuilt = house.Door.IsBuilt;
            bool roofBuilt = house.Roof.IsBuilt;
            bool wallsBuilt = Array.TrueForAll(house.Walls, w => w.IsBuilt);
            bool windowsBuilt = Array.TrueForAll(house.Windows, w => w.IsBuilt);

            return basementBuilt && wallsBuilt && windowsBuilt && doorBuilt && roofBuilt;
        }
    }
}
