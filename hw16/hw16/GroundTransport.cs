namespace TransportHierarchy
{
    public class GroundTransport : Transport
    {
        public override string Name => "Ground Transport";
    }
    public class Car : GroundTransport
    {
        public override string Name => "Car";
    }
    public class Horse : GroundTransport
    {
        public override string Name => "Horse";
    }
    public class Train : GroundTransport
    {
        public override string Name => "Train";
    }

}
