// See https://aka.ms/new-console-template for more information
using Fraction;

Console.Write("Input the Denominator: ");
var DenominatorFromUser = Console.ReadLine();
Console.Write("\nInput the Numerator: ");
var Numerator = Console.ReadLine();
if(int.TryParse(DenominatorFromUser, out int Denominator))
{
    
}
FractionItem first = new FractionItem(1, 2);
FractionItem second = new FractionItem(1, 3);
var firstHash = first.GetHashCode();
var secondHash = second.GetHashCode();
Console.WriteLine("Firsthash: " + firstHash + " SecondHash: " +secondHash);
Console.WriteLine(first + second);
Console.WriteLine(first / second);  
Console.WriteLine(first - second);  
Console.WriteLine(first * second);  