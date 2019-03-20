using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void When_StringIsEmpty_Expect_0()
        {
            string numbers = "";
            int expected = 0;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_StringIsNumber_Expect_NumberAsInt()
        {
            string numbers = "1";
            int expected = 1;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_StringIsMultipleNumbers_Expect_SumAsInt()
        {
            string numbers = "1,2";
            int expected = 3;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_DelimiterIsNewLineOrComma_Expect_SumAsInt()
        {
            string numbers = "1\n2,3";
            int expected = 6;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_CustomDelimiterUsed_Expect_SumAsInt()
        {
            string numbers = "//;\n1;2;3";
            int expected = 6;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

    }
}
