using Fraction.Interfaces;


namespace Fraction
{
    internal class MathStuff : IMathStuff
    {
        // Use Euclid's algorithm to calculate the
        // greatest common divisor (GCD) of two numbers.
        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Pull out remainders.
            for (; ; )
            {
                int remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }
    }
}
