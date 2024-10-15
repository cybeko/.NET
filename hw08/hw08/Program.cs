using hw08;

string[] duties = { "Estimating costs and timelines", "Supervising production", "Conduct research" };
Employee emp = new Employee(
    "John Doe",
    22,
    "0969305573",
    "examp@gmail.com",
    "Engineer",
    new DateOnly(1984, 3, 24),
    duties
);

emp.DisplayInfo();

Employee emp1 = new Employee();
emp1.InputData();
emp1.DisplayInfo();


Airplane f16 = new Airplane
{
    Name = "F-16 Fighting Falcon",
    Manufacturer = "Lockheed Martin",
    Type = "Multirole fighter",
    Year = 1974
};
f16.DisplayInfo();