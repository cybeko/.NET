namespace TransportHierarchy
{
    public class AirTransport : Transport
    {
        public override string Name => "Air Transport";
    }
    public class Airplane : AirTransport
    {
        public override string Name => "Airplane";
    }
    public class Helicopter : AirTransport
    {
        public override string Name => "Helicopter";
    }
    public class Airship : AirTransport
    {
        public override string Name => "Airship";
    }

}
