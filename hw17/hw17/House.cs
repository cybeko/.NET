namespace BuildingHouse
{
    public class House
    {
        public Basement Basement { get; } = new Basement();
        public Wall[] Walls { get; } = new Wall[4];
        public Door Door { get; } = new Door();
        public Window[] Windows { get; } = new Window[4];
        public Roof Roof { get; } = new Roof();

        public List<IPart> Parts { get; } = new List<IPart>();

        public House()
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                Walls[i] = new Wall();
            }
            for (int i = 0; i < Windows.Length; i++)
            {
                Windows[i] = new Window();
            }

            Parts.Add(Basement);
            Parts.AddRange(Walls);
            Parts.Add(Door);
            Parts.AddRange(Windows);
            Parts.Add(Roof);
        }
        public int TotalParts => Parts.Count;
    }
}