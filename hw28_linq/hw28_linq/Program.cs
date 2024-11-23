using hw28_linq;
class Program
{
    static void WriteResults<T>(IEnumerable<T> res_1, string description)
    {
        Console.WriteLine(description);
        foreach (var item in res_1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    static void WriteResults<T>(T res_1, string description)
    {
        Console.WriteLine(description);
        Console.WriteLine(res_1);
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        List<Phone> phones = new List<Phone>()
        {
            new Phone("OnePlus 11", "OnePlus", 659, new DateOnly(2023, 2, 7)),
            new Phone("Xperia 1 IV", "Sony", 1199, new DateOnly(2022, 5, 11)),
            new Phone("Samsung Galaxy Z Fold 5", "Samsung", 1799, new DateOnly(2023, 8, 11)),
            new Phone("iPhone 14", "Apple", 899, new DateOnly(2022, 9, 16)),
            new Phone("Google Pixel 7a", "Google", 449, new DateOnly(2023, 5, 10)),
            new Phone("Xiaomi 13", "Xiaomi", 749, new DateOnly(2023, 2, 26)),
            new Phone("Oppo Find X6 Pro", "Oppo", 1199, new DateOnly(2023, 3, 21)),
            new Phone("iPhone 15", "Apple", 999, new DateOnly(2023, 9, 22)),
            new Phone("Galaxy S23", "Samsung", 1999, new DateOnly(2023, 2, 17)),
            new Phone("Pixel 8", "Google", 99, new DateOnly(2023, 10, 4)),
            new Phone("Pixel 8", "Google", 99, new DateOnly(2023, 10, 4))
        };
        var res = phones.Select(p => p).Count();
        WriteResults(res, "Посчитайте количество телефонов");

        res = phones.Where(p => p.Price > 100).Count();
        WriteResults(res, "Посчитайте количество телефонов с ценой больше 100");

        res = phones.Where(p => p.Price > 400 && p.Price < 700).Count();
        WriteResults(res, "Посчитайте количество телефонов с ценой в диапазоне от 400 до 700");

        string manufacturer = "Apple";
        res = phones.Where(p => p.Manufacturer == manufacturer).Count();
        WriteResults(res, "Посчитайте количество телефонов конкретного производителя");

        var res2 = phones.OrderBy(p => p.Price).First();
        WriteResults(res2, "Найдите телефон с минимальной ценой");

        res2 = phones.OrderByDescending(p => p.Price).First();
        WriteResults(res2, "Найдите телефон с максимальной ценой");

        res2 = phones.OrderBy(p => p.ReleaseDate).First();
        WriteResults(res2, "Отобразите информацию о самом старом телефоне");

        res2 = phones.OrderByDescending(p => p.ReleaseDate).First();
        WriteResults(res2, "Отобразите информацию о самом свежем телефоне");

        var res3 = phones.Average(p => p.Price);
        WriteResults(res3, "Найдите среднюю цену телефона");

        var res4 = phones.OrderByDescending(p => p.Price).Take(5);
        WriteResults(res4, "Отобразите пять самых дорогих телефонов");

        res4 = phones.OrderBy(p => p.Price).Take(5);
        WriteResults(res4, "Отобразите пять самых дешевых телефонов");

        res4 = phones.OrderBy(p => p.ReleaseDate).Take(3);
        WriteResults(res4, "Отобразите три самых старых телефона");

        res4 = phones.OrderByDescending(p => p.ReleaseDate).Take(3);
        WriteResults(res4, "Отобразите три самых новых телефона");

        var manufacturerStats = phones
              .GroupBy(p => p.Manufacturer)
              .Select(g => new { Manufacturer = g.Key, Count = g.Count() });
        WriteResults(manufacturerStats, "Статистика по количеству телефонов каждого производителя");

        var modelStats = phones
                .GroupBy(p => p.ModelName)
                .Select(g => new { Model = g.Key, Count = g.Count() });
        WriteResults(modelStats, "Статистика по количеству моделей телефонов");

        var yearStats = phones
            .GroupBy(p => p.ReleaseDate.Year)
            .Select(g => new { Year = g.Key, Count = g.Count() });
        WriteResults(yearStats, "Статистика телефонов по годам");
    }
}

