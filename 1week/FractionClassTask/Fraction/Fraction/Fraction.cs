using Fraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public readonly IMathStuff _mathStuff;
        public Fraction(IMathStuff mathStuff) => _mathStuff = mathStuff;
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
        public Fraction(string txt)
        {
            string[] pieces = txt.Split('/');
            Numerator = int.Parse(pieces[0]);
            Denominator = int.Parse(pieces[1]);
            Simplify(Numerator, Denominator);
        }
        //Summary
        // Initialize the fraction from numerator and denominator.
        //Summary

        public Fraction(int numer, int denom)
        {
            Numerator = numer;
            Denominator = denom;
            Simplify(Numerator, Denominator);
        }
        //Summary
        //Multiply method Return a * b.
        //Summary
        public static Fraction operator *(Fraction a, Fraction b)
        {
            // Swap numerators and denominators to simplify.
            Fraction result1 = new Fraction(a.Numerator, b.Denominator);
            Fraction result2 = new Fraction(b.Numerator, a.Denominator);

            return new Fraction(
                result1.Numerator * result2.Numerator,
                result1.Denominator * result2.Denominator);
        }
        //Summary
        // Mrthod for substraction Return -a.
        //Summary
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        // Return a + b.
        public static Fraction operator +(Fraction a, Fraction b)
        {
            // Get the denominators' greatest common divisor.
            int gcd_ab = _mathStuff.GCD(a.Denominator, b.Denominator);

            int numer =
                a.Numerator * (b.Denominator / gcd_ab) +
                b.Numerator * (a.Denominator / gcd_ab);
            int denom =
                a.Denominator * (b.Denominator / gcd_ab);
            return new Fraction(numer, denom);
        }

        // Return a - b.
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + -b;
        }

        // Return a / b.
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * new Fraction(b.Denominator, b.Numerator);
        }

        // Simplify the fraction.
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
            int gcd_ab = IMathStuff.GCD(Numerator, Denominator);
            Numerator = Numerator / gcd_ab;
            Denominator = Denominator / gcd_ab;
        }

        //Summary
        // Convert a to a double.
        //Summary
        public static implicit operator double(Fraction a)
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
    }
}
