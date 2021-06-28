using System;
using System.Collections.Generic;
using System.Text;
using FFX_CodingChallenge.Models;


namespace FFX_CodingChallenge
{
    internal class PostCodeProcessor
    {
        public void Run()
        {
            var inputList = new List<string> { "M28 7JP", "WC2H7DE", "CT21           4LR", "N33DP" };

            foreach (var input in inputList)
            {
                var postcode = new PostCode(input);
                var output = GetPrintDetails(postcode);
                Console.WriteLine(output);
            }

        }


        private string GetPrintDetails(PostCode postCode)
        {
            if (!postCode.IsValid)
                return "# INVALID POSTCODE: " + postCode.RawPostCode;

            var output = new StringBuilder();

            output.AppendLine("# POSTCODE: " + postCode.CleanPostCode);
            output.AppendLine("\tOUTWARD CODE: " + postCode.OutwardCode);
            output.AppendLine("\t\tOUTWARD LETTER: " + postCode.OutwardLetter);
            output.AppendLine("\t\tOUTWARD NUMBER: " + postCode.OutwardNumber);

            output.AppendLine("\tINWARD CODE: " + postCode.InwardCode);

            return output.ToString();
        }
    }
}

