using System;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public Rational(double numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Rational(double numerator, double denominator)
        {
            if (denominator % numerator == 0 && numerator != 1)
            {
                var tempNumerator = numerator;
                numerator = denominator < 0 && numerator < 0 ? 1 : denominator < 0 || numerator < 0 ? -1 : 1;
                denominator = Math.Abs(denominator / tempNumerator);
            }


            Numerator = numerator;
            Denominator = numerator == 0 ? 1 : denominator;
            IsNan = denominator == 0;
        }

        public static Rational operator +(Rational c1, Rational c2)
        {
            return new Rational(c1.Numerator * c2.Denominator + c2.Numerator * c1.Denominator, c1.Denominator * c2.Denominator);
        }
        public static Rational operator -(Rational c1, Rational c2)
        {
            return new Rational(c1.Numerator * c2.Denominator - c2.Numerator * c1.Denominator, c1.Denominator * c2.Denominator);
        }

        public static Rational operator *(Rational c1, Rational c2)
        {
            return new Rational(c1.Numerator * c2.Numerator, c1.Denominator * c2.Denominator);
        }

        public static Rational operator /(Rational c1, Rational c2)
        {
            var r = new Rational(c1.Numerator * c2.Denominator, c2.Numerator * c1.Denominator);
            r.IsNan = r.IsNan||c1.Denominator == 0 || c2.Denominator == 0;
            return r;
        }

        public static implicit operator Rational(int numerator)
        {
            return new Rational(numerator);
        }

        public static implicit operator double(Rational rational)
        {
            return rational.Numerator / rational.Denominator;
        }

        public static implicit operator int(Rational rational)
        {
            if (rational.Numerator % rational.Denominator == 0)
                return (int)(rational.Numerator / rational.Denominator);
            else
                throw new ArgumentException();
        }

        public double Denominator { get; set; }
        public bool IsNan { get; set; }
        public double Numerator { get; set; }
    }
}
