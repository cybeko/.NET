using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public ComplexNumber() : this(0, 0) { }
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static ComplexNumber Add(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.Real + num2.Real, num1.Imaginary + num2.Imaginary);
        }
        public static ComplexNumber Subtract(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.Real - num2.Real, num1.Imaginary - num2.Imaginary);
        }
        public static ComplexNumber Divide(ComplexNumber num1, ComplexNumber num2)
        {
            double denom = num2.Real * num2.Real + num2.Imaginary * num2.Imaginary;
            if (denom == 0)
                throw new DivideByZeroException("Cannot divide by 0.");

            double real = (num1.Real * num2.Real + num1.Imaginary * num2.Imaginary) / denom;
            double imaginary = (num1.Imaginary * num2.Real - num1.Real * num2.Imaginary) / denom;
            return new ComplexNumber(real, imaginary);
        }
        public static ComplexNumber Multiply(ComplexNumber num1, ComplexNumber num2)
        {
            double realPart = num1.Real * num2.Real - num1.Imaginary * num2.Imaginary;
            double imaginaryPart = num1.Real * num2.Imaginary + num1.Imaginary * num2.Real;
            return new ComplexNumber(realPart, imaginaryPart);
        }
        public override readonly string ToString() => $"{Real} + {Imaginary}i";
    }
}
