using System.Linq;
using System.Text.RegularExpressions;

namespace FFX_CodingChallenge.Models
{
    internal class PostCode
    {
        readonly string pattern = @"^(?<outwardCode>[A-Z][A-Z\d]{1,3})(?<inwardCode>\d[A-Z\d]{2})$";

        public PostCode(string postCode)
        {
            RawPostCode = postCode;

            CleanPostCode = Regex.Replace(postCode, @"\s", "").ToUpper();

            var matches = Regex.Matches(CleanPostCode, pattern);

            if (matches.Count == 0)
            {
                IsValid = false;
            }
            else
            {
                IsValid = true;

                OutwardCode = matches[0].Groups["outwardCode"].Value;
                OutwardLetter = new string(OutwardCode.TakeWhile(char.IsLetter).ToArray());
                OutwardNumber = new string(OutwardCode.SkipWhile(char.IsLetter).ToArray());

                InwardCode = matches[0].Groups["inwardCode"].Value;
            }
        }

        public string RawPostCode { get; }

        public string CleanPostCode { get; }

        public string OutwardCode { get; }

        public string OutwardLetter { get; }

        public string OutwardNumber { get; }

        public string InwardCode { get; }

        public bool IsValid { get; }

    }
}