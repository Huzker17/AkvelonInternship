// See https://aka.ms/new-console-template for more information
// Task's Link https://github.com/Rust1k/Internship-.NET-/blob/main/week%201/Fraction.md
using Fraction;


FractionItem first = new FractionItem(1, 2);
FractionItem second = new FractionItem(1, 2);
FractionItem third = new FractionItem(1, 4);

var firstHash = first.GetHashCode();
var secondHash = second.GetHashCode();
var thirdHash = third.GetHashCode();

Console.WriteLine("Firsthash: " + firstHash + " SecondHash: " +secondHash + " \nThirdHash: " +thirdHash);
Console.WriteLine(first + second);
Console.WriteLine(first / second);  
Console.WriteLine(first - second);  
Console.WriteLine(first * second);
Console.WriteLine(first.Equals(second));
Console.WriteLine(first.Equals(third));