using System.Collections.Generic;
using FFX_CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_FFX_CodingChallenge
{
    [TestClass]
    public class FizzBuzzTests
    {
        private static FizzBuzzGenerator _fizzBuzzGenerator;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _fizzBuzzGenerator = new FizzBuzzGenerator();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Test_GetFizzBuzz(int number, string expected)
        {
            var result = _fizzBuzzGenerator.GetFizzBuzz(number);
            Assert.AreEqual(result, expected);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, "1" };
            yield return new object[] { 3, "Fizz" };
            yield return new object[] { 6, "Fizz" };
            yield return new object[] { 5, "Buzz" };
            yield return new object[] { 10, "Buzz" };
            yield return new object[] { 15, "FizzBuzz" };
        }
    }
}

