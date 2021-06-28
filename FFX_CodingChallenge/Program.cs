using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests_FFX_CodingChallenge")]

namespace FFX_CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzzGenerator();
            var postCode = new PostCodeProcessor();

            fizzBuzz.Run();
            postCode.Run();
        }
    }
}
