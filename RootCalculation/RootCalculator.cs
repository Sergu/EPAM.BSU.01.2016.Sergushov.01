using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootCalculation
{
    /// <summary>
    /// Предоставляет статические методы для вычисления корней числа.
    /// </summary>
    public static class RootCalculator
    {
        /// <summary>
        /// Вычисляет корень n-ой степени из числа методом Ньютона с заданной точностью.
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="power">степень корня</param>
        /// <param name="correctness">заданная точность</param>
        /// <returns>корень числа</returns>
        public static double CalcRoot(double number, double power, double correctness)
        {
            double x0 = number / 2;
            double x1 = 1 / power * ((power - 1) * x0 + number / Math.Pow(x0, power - 1));
            while (Math.Abs(x1 - x0) > correctness)
            {
                x0 = x1;
                x1 = 1 / power * ((power - 1) * x0 + number / Math.Pow(x0, power - 1));
            }
            return x1;
        }
    }
}
