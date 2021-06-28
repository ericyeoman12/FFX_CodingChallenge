using System;
using System.Linq;

namespace FFX_CodingChallenge
{

    internal class FizzBuzzGenerator
    {
        public void Run()
        {
            Enumerable.Range(1, 100)
                .Select(GetFizzBuzz)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public string GetFizzBuzz(int number)
        {
            var result = string.Empty;

            if (number % 3 == 0)
                result = "Fizz";
            if (number % 5 == 0)
                result += "Buzz";

            return (result.Equals(string.Empty) ? number.ToString() : result);
        }
    }
}
