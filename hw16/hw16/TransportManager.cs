namespace TransportHierarchy
{
    public class TransportManager
    {
        public void Start()
        {
            Console.WriteLine("Select a transport:");
            Console.WriteLine("1. Car" +
                "\n2. Horse" +
                "\n3. Train" +
                "\n4. Airplane" +
                "\n5. Helicopter" +
                "\n6. Airship" +
                "\n7. MotorShip" +
                "\n8. CargoShip" +
                "\n9. Boat");

            string u_choice = Console.ReadLine() ?? string.Empty;

            Transport u_transport = u_choice switch
            {
                "1" => new Car(),
                "2" => new Horse(),
                "3" => new Train(),
                "4" => new Airplane(),
                "5" => new Helicopter(),
                "6" => new Airship(),
                "7" => new MotorShip(),
                "8" => new CargoShip(),
                "9" => new Boat(),
                _ => throw new Exception("Option doesn't exist")
            };

            if (u_transport != null)
            {
                Console.WriteLine($"Transport: {u_transport.Name}");
                u_transport.Move();
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }
    }
}
