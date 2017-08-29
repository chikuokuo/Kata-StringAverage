using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringAverage
{

    //You are given a string of numbers between 0-9. Find the average of these numbers and return it 
    //as a floored whole number (ie: no decimal places) written out as a string. Eg:

    //"zero nine five two" -> "four"

    //If the string is empty or includes a number greater than 9, return "n/a"

    [TestClass]
    public class StringAverageTest
    {
        [TestMethod]
        public void String_Empty_ShouldReturn_NA()
        {
            StringAverageShouldEqual(string.Empty, "n/a");
        }

        private static void StringAverageShouldEqual(string input, string expected)
        {
            StringAverage stringAverage = new StringAverage();
            var result = stringAverage.AverageString(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_one_ShouldReturn_one()
        {
            StringAverageShouldEqual("one", "one");
        }

        [TestMethod]
        public void String_one_three_ShouldReturn_two()
        {
            StringAverageShouldEqual("one three", "two");
        }

        [TestMethod]
        public void String_two_four_six_ShouldReturn_four()
        {
            StringAverageShouldEqual("two four six", "four");
        }

        [TestMethod]
        public void String_five_eight_ShouldReturn_six()
        {
            StringAverageShouldEqual("five eight", "six");
        }

        [TestMethod]
        public void String_sdeff_ShouldReturn_na()
        {
            StringAverageShouldEqual("sdeff", "n/a");
        }

        [TestMethod]
        public void stringAverage_Should_Equal()
        {
            var stringAverage = new StringAverage();
            Assert.AreEqual("four", stringAverage.AverageString("zero nine five two"));
            Assert.AreEqual("three", stringAverage.AverageString("four six two three"));
            Assert.AreEqual("three", stringAverage.AverageString("one two three four five"));
            Assert.AreEqual("four", stringAverage.AverageString("five four"));
            Assert.AreEqual("zero", stringAverage.AverageString("zero zero zero zero zero"));
            Assert.AreEqual("two", stringAverage.AverageString("one one eight one"));
            Assert.AreEqual("n/a", stringAverage.AverageString(""));
        }
    }

    public class StringAverage
    {
        private readonly Dictionary<string, int> stringMapInt = new Dictionary<string, int>()
            {
                {"zero", 0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

        public string AverageString(string input)
        {
            var inputNumbers = input.Split(' ');

            if (inputNumbers.Any(x => string.IsNullOrEmpty(x) || !stringMapInt.ContainsKey(x)))
            {
                return "n/a";
            }

            return stringMapInt.Single(x => x.Value == inputNumbers.Sum(y => stringMapInt[y]) / inputNumbers.Length).Key;
        }
    }
}
