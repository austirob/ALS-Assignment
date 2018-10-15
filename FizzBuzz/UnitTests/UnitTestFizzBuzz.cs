using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestFizzBuzz

    {
        [TestMethod]
        public void TestFizz()
        {
            const string str = "Fizz";
            Assert.AreEqual(FizzBuzz.EvaluateFizzBuzz.Print(3), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(4), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(5), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(15), str);
        }
        

        [TestMethod]
        public void TestBuzz()
        {
            const string str = "Buzz";
            Assert.AreEqual(FizzBuzz.EvaluateFizzBuzz.Print(5), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(3), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(6), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(15), str);
        }

        [TestMethod]
        public void TestFizzBuzz()
        {
            const string str = "FizzBuzz";
            Assert.AreEqual(FizzBuzz.EvaluateFizzBuzz.Print(15), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(4), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(3), str);
            Assert.AreNotEqual(FizzBuzz.EvaluateFizzBuzz.Print(6), str);
        }

    }
}
