namespace TransportHierarchy
{
    public abstract class Transport 
    {
        public abstract string Name { get; }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving");
        }
    }
}
