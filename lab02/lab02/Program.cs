using lab02;

ComplexNumber complex1 = new(3, 4);
ComplexNumber complex2 = new(2, 2);

Console.WriteLine("Complex number 1: " + complex1);
Console.WriteLine("Complex number 2: " + complex2);

Console.WriteLine(ComplexNumber.Add(complex1, complex2));
Console.WriteLine(ComplexNumber.Subtract(complex1, complex2));
Console.WriteLine(ComplexNumber.Multiply(complex1, complex2));
Console.WriteLine(ComplexNumber.Divide(complex1, complex2));