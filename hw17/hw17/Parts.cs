
namespace BuildingHouse
{
    public class Basement : IPart
    {
        public bool IsBuilt { get; set; } = false;
        public string PartName => "Basement";
    }

    public class Wall : IPart
    {
        public bool IsBuilt { get; set; } = false;
        public string PartName => "Wall";
    }

    public class Door : IPart
    {
        public bool IsBuilt { get; set; } = false;
        public string PartName => "Door";
    }

    public class Window : IPart
    {
        public bool IsBuilt { get; set; } = false;
        public string PartName => "Window";
    }

    public class Roof : IPart
    {
        public bool IsBuilt { get; set; } = false;
        public string PartName => "Roof";
    }

}
