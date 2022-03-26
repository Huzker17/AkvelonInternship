
namespace Fraction
{
    public class FractionItem
    {
        //Summary
        //Immutable field for Numerator
        //Summary
        public int Numerator { get; init; }
        //Summary
        //Immutable field for Denominator
        //Summary
        public int Denominator { get; init; }
        //Summary
        // Initialize the fraction from a string A/B.
        //Summary



        public FractionItem(int numer, int denom)
        {
            if (numer.GetType() != typeof(int) && denom.GetType() != typeof(int))
                throw new ArgumentException("Both of parameters should be type of Int");
            if (denom == 0)
                throw new ArgumentException("Denominator can't zero");
            Numerator = numer;
            Denominator = denom;
            Simplify(Numerator, Denominator);
        }
        //Summary
        //Multiply method Return a * b.
        //Summary
        public static FractionItem operator *(FractionItem a, FractionItem b)
        {
            // Swap numerators and denominators to simplify.
            FractionItem result1 = new FractionItem(a.Numerator, b.Denominator);
            FractionItem result2 = new FractionItem(b.Numerator, a.Denominator);

            return new FractionItem(result1.Numerator * result2.Numerator,
                                result1.Denominator * result2.Denominator);
        }
        //Summary
        // Method For negative digits.
        //Summary
        public static FractionItem operator -(FractionItem a)
        {
            return new FractionItem(-a.Numerator, a.Denominator);
        }
        //Summary
        // Method for Add Return a + b.
        //Summary
        public static FractionItem operator +(FractionItem a, FractionItem b)
        {
            // Get the denominators' greatest common divisor.
            int gcd_ab = MathStuff.GCD(a.Denominator, b.Denominator);

            int numer = a.Numerator * (b.Denominator / gcd_ab) +
                        b.Numerator * (a.Denominator / gcd_ab);
            int denom = a.Denominator * (b.Denominator / gcd_ab);
            return new FractionItem(numer, denom);
        }
        //Summary
        //Method for Substraction Return a - b.
        //Summary
        public static FractionItem operator -(FractionItem a, FractionItem b)
        {
            return a + -b;
        }
        //Summary
        // Method for dividing Return a / b.
        //Summary
        public static FractionItem operator /(FractionItem a, FractionItem b)
        {
            return a * new FractionItem(b.Denominator, b.Numerator);
        }
        //Summary
        // Simplify the fraction.
        //Summary
        private void Simplify( int Numerator, int Denominator)
        {
            // Simplify the sign.
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
            // Factor out the greatest common divisor of the
            // numerator and the denominator.
            int gcd_ab = MathStuff.GCD(Numerator, Denominator);
            Numerator = Numerator / gcd_ab;
            Denominator = Denominator / gcd_ab;
        }

        //Summary
        // Convert a to a double.
        //Summary
        public static implicit operator double(FractionItem a)
        {
            return (double)a.Numerator / a.Denominator;
        }
        //Summary
        // Return the fraction's value as a string.
        //Summary
        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }
        public override int GetHashCode()
        {
            int hash = 17;
            // Suitable nullity checks etc, of course :)
            hash = hash * 23 + Denominator.GetHashCode();
            hash = hash * 23 + Numerator.GetHashCode();
            return hash;
        }
        public override bool Equals(Object? Com)
        {
            this.Equals(Com);
            return true;
        }
    }
}
