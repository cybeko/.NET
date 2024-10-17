using hw06_09;

string showdate;
MyDate myDate1 = new MyDate(2005, 10, 26);
Console.WriteLine(myDate1.ShowDate(myDate1));

MyDate myDate2 = new MyDate(2005, 10, 24);
Console.WriteLine(myDate2.ShowDate(myDate2));

MyDate compareDates = new MyDate();
int difference = compareDates.CompareDates(myDate1, myDate2);
Console.WriteLine($"Difference in days: {difference}");

MyDate newDate = myDate1.ChangeDate(myDate1, 2);
Console.WriteLine($"Old date: {myDate1.ShowDate(myDate1)}");
Console.WriteLine($"New date: {newDate.ShowDate(newDate)}");


