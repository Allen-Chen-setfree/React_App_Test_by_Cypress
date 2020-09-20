using System;

namespace api.Services
{
    public class FactorialCalculator
    {
        private const int MaxN = 10;

        public int Calculate(int n) => n > MaxN || n <= 0
            ? throw new NotSupportedException($"n > {MaxN} or n <= 0 is not supported")
            : Factorial(n);

        private static int Factorial(int n)
        {
            var x = 1;
            while (n != 1) x *= n--;
            return x;
        }
    }
}