using hw11_overloading;
using Books;

Journal j1 = new Journal("J1", "Desc", 1998, "380962304173", "iso@gmail.com", 50);
Journal j2 = new Journal("J2", "Desc", 1998, "380962304173", "iso@gmail.com", 50);

j1.DisplayInfo();
j2.DisplayInfo();

j1 = j1 + 10;
j1.DisplayInfo();

j1 = j1 - 5;
j1.DisplayInfo();

if (j1 > j2) Console.WriteLine("j1 > j2: True");
if (j1 < j2) Console.WriteLine("j1 < j2: True");

if (j1 == j2) Console.WriteLine("j1 == j2: True");
if (j1 != j2) Console.WriteLine("j1 != j2: True");


Shop s1 = new Shop("S1", "Desc", "N. street", "380962304173", "iso@gmail.com", 45);
Shop s2 = new Shop("S2", "Desc", "M. street", "380962304173", "iso@gmail.com", 50);

s1.DisplayInfo();
s2.DisplayInfo();

s1 = s1 + 10;
s1.DisplayInfo();

s1 = s1 - 5;
s1.DisplayInfo();

if (s1 > s2) Console.WriteLine("s1 > s2: True");
if (s1 < s2) Console.WriteLine("s1 < s2: True");

if (s1 == s2) Console.WriteLine("s1 == s2: True");
if (s1 != s2) Console.WriteLine("s1 != s2: True");

ToReadList l1 = new ToReadList("Book1", "Book2", "Book3");
ToReadList l2 = new ToReadList("Book1", "Book2", "Book3", "B4", "B5");
l1.DisplayList();

Console.WriteLine(l1[1]); 
Console.WriteLine(l1["2"]);

l1 += "Book4";
l1.DisplayList();

l1 -= "Book4";
l1.DisplayList();

if (l1 > l2) Console.WriteLine("l1 > l2: True");
if (l1 < l2) Console.WriteLine("l1 < l2: True");

if (l1 == l2) Console.WriteLine("l1 == l2: True");
if (l1 != l2) Console.WriteLine("l1 != l2: True");