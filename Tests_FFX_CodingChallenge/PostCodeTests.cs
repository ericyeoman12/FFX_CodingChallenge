using System.Collections.Generic;
using FFX_CodingChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_FFX_CodingChallenge
{
    [TestClass]
    public class PostCodeTests
    {

        [DataTestMethod]
        [DynamicData(nameof(Get_RawPostCode_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_WholePostCode(string postCode, string expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.CleanPostCode, expected);
        }

        public static IEnumerable<object[]> Get_RawPostCode_Data()
        {
            yield return new object[] { "M28 7JP", "M287JP" };
            yield return new object[] { "WC2H7DE", "WC2H7DE" };
            yield return new object[] { "CT21           4LR", "CT214LR" };
            yield return new object[] { "N33DP", "N33DP" };
        }


        [DataTestMethod]
        [DynamicData(nameof(Get_Outward_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_OutwardData(string postCode, string expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.OutwardCode, expected);
        }

        public static IEnumerable<object[]> Get_Outward_Data()
        {
            yield return new object[] { "M28 7JP", "M28" };
            yield return new object[] { "WC2H7DE", "WC2H" };
            yield return new object[] { "CT21           4LR", "CT21" };
            yield return new object[] { "N33DP", "N3" };
        }


        [DataTestMethod]
        [DynamicData(nameof(Get_OutwardLetter_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_OutwardLetterData(string postCode, string expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.OutwardLetter, expected);
        }

        public static IEnumerable<object[]> Get_OutwardLetter_Data()
        {
            yield return new object[] { "M28 7JP", "M" };
            yield return new object[] { "WC2H7DE", "WC" };
            yield return new object[] { "CT21           4LR", "CT" };
            yield return new object[] { "N33DP", "N" };
        }


        [DataTestMethod]
        [DynamicData(nameof(Get_OutwardNumber_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_OutwardNumberData(string postCode, string expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.OutwardNumber, expected);
        }

        public static IEnumerable<object[]> Get_OutwardNumber_Data()
        {
            yield return new object[] { "M28 7JP", "28" };
            yield return new object[] { "WC2H7DE", "2H" };
            yield return new object[] { "CT21           4LR", "21" };
            yield return new object[] { "N33DP", "3" };
        }


        [DataTestMethod]
        [DynamicData(nameof(Get_Inward_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_InwardData(string postCode, string expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.InwardCode, expected);
        }

        public static IEnumerable<object[]> Get_Inward_Data()
        {
            yield return new object[] { "M28 7JP", "7JP" };
            yield return new object[] { "WC2H7DE", "7DE" };
            yield return new object[] { "CT21           4LR", "4LR" };
            yield return new object[] { "N33DP", "3DP" };
        }

        [DataTestMethod]
        [DynamicData(nameof(Get_Validating_Data), DynamicDataSourceType.Method)]
        public void Test_ProcessPostCode_IsValid(string postCode, bool expected)
        {
            var result = new PostCode(postCode);
            Assert.AreEqual(result.IsValid, expected);
        }


        public static IEnumerable<object[]> Get_Validating_Data()
        {
            yield return new object[] { "M28 7JP", true };
            yield return new object[] { "WC2H7DE", true };
            yield return new object[] { "CT21           4LR", true };
            yield return new object[] { "N33DP", true };

            yield return new object[] { "1WR 2BH", false };     // Starts with number
            yield return new object[] { "CT6669LP", false };    // Too Long
            yield return new object[] { "CT6P", false };        // Too Short
            yield return new object[] { "CT66LP9", false };     // Inward starts with letter
            yield return new object[] { "CT66.P9", false };     // Contains invalid character
        }
    }
}

