using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RootCalculation;

namespace UnitTest
{
    [TestClass]
    public class UnitTestRootCalc
    {
        [TestMethod]
        public void TestCalcRoot()
        {
            Random rand = new Random();
            double number = rand.Next(1, 100000);
            double power = rand.Next(1, 1000);
            double correctness = rand.Next(10000, 1000000);
            double myFuncResult = RootCalculator.CalcRoot(number, power, 1/correctness);
            double MathPowResult = Math.Pow(number, 1 / power);
            Assert.IsTrue(Math.Abs(myFuncResult - MathPowResult) <= 1 / correctness);
        }
    }
}
