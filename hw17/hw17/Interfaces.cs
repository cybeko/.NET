
namespace BuildingHouse
{
    public interface IPart
    {
        bool IsBuilt { get; set; }
        string PartName { get; }
    }

    public interface IWorker
    {
        string FirstName { get; }
        string LastName { get; }
        void Work(House house);
    }
}
