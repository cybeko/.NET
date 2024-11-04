using Delegate;
using hw18_delegate;
using static Delegate.ArrayManager;
using static Delegate.EverythingManager;
#region 1

int[] array = [2, 7, 1, 11, 22, 29, 3, 4, 5, 8, 13, 21];

ArrayDelegate getEven = new(GetEvenNumbers);
ArrayDelegate getOdd = new(GetOddNumbers);
ArrayDelegate getPrime = new(GetPrimeNumbers);
ArrayDelegate getFibonacci = new(GetFibonacciNumbers);

Console.WriteLine("getEven: " + string.Join(", ", getEven(array)));
Console.WriteLine("getOdd: " + string.Join(", ", getOdd(array)));
Console.WriteLine("getPrime: " + string.Join(", ", getPrime(array)));
Console.WriteLine("getFibonacci: " + string.Join(", ", getFibonacci(array)));
#endregion
#region 2

DisplayDelegate displayTime = new(DisplayCurrentTime);
DisplayDelegate displayDate = new(DisplayCurrentDate);
DisplayDelegate displayDay = new(DisplayCurrentDayOfWeek);

displayTime();
displayDate();
displayDay();

AreaDelegate triangleAreaDelegate = new(CalculateTriangleArea);
AreaDelegate rectangleAreaDelegate = new(CalculateRectangleArea);

double triangleArea = triangleAreaDelegate(5, 10);
double rectangleArea = rectangleAreaDelegate(4, 6);
Console.WriteLine($"Triangle: {triangleArea}");
Console.WriteLine($"Rectangle: {rectangleArea}");
#endregion

#region 3
CreditCard card = new CreditCard("4532123456789010", "John Doe", "5632", new DateOnly(2025, 12, 31), 2500, 1000);
CreditCardMessage msg = new CreditCardMessage();

msg.Subscribe(card);
card.PrintCard();

card.PutMoney(500);
card.WithdrawMoney(1500);
card.ChangePin("2235");
card.CheckMoneyGoal(1500);
card.WithdrawMoney(1500);
#endregion