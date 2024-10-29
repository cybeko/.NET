namespace TransportHierarchy
{
    public class WaterTransport : Transport
    {
        public override string Name => "Water Transport";
    }
    public class CargoShip : WaterTransport
    {
        public override string Name => "Cargo Ship";
    }
    public class Boat : WaterTransport
    {
        public override string Name => "Boat";
    }
    public class MotorShip : WaterTransport
    {
        public override string Name => "Motor Ship";
    }
}
