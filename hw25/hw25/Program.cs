using hw25;

Money a = new Money(10, 50);
Money b = new Money(2, 75);

Money c = a + b;
Console.WriteLine(c);

Money d = a - b;
Console.WriteLine(d);

a++;
Console.WriteLine(a);

b--;
Console.WriteLine(b);

Money.CloseLog();