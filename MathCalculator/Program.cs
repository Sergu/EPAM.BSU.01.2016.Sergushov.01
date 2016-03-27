using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootCalculation;
using ArraySorting;

namespace MathCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][]{
                new int[] {4,-13,102,235,123 },
                new int[] {-12},
                new int[] {}
            };
            //BubbleSortDelegates.BubbleSort(arr, new BubbleSortDelegates.CompareDelegate(ArrayComparer.CompareByMaxElem));
            BubbleSortInterfaces.BubbleSort(arr, new ComparerRowSum());


            string choise = "y";
            while(choise != "n")
            {
                Console.WriteLine("Enter number for root calculation");
                double number;
                double.TryParse(Console.ReadLine(), out number);
                Console.WriteLine("Enter power for root calculation");
                double power;
                double.TryParse(Console.ReadLine(), out power);
                Console.WriteLine("Enter correctness");
                double correctness;
                double.TryParse(Console.ReadLine(), out correctness);
                double resMyFunc = RootCalculator.CalcRoot(number, power, correctness);
                Console.WriteLine(" MyFunc result : {0}", resMyFunc);
                double resMathPow = Math.Pow(number, 1 / power);
                Console.WriteLine(" Math.Pow result: {0}", resMathPow);
                if(Math.Abs(resMathPow - resMyFunc)<=correctness)
                {
                    Console.WriteLine("    Result : true");
                }
                else
                {
                    Console.WriteLine("    Result : false");
                }
                Console.Write("Do you want to repeat? (y - yes / n - no) ...");
                choise = Console.ReadLine();
            }
        }
    }
}
