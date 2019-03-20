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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void When_NegativeNumberUsed_Expect_ThrowExeption()
        {
            string numbers = "-1";
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void When_MultipleNegativeNumberUsed_Expect_ThrowExeption()
        {
            string numbers = "-5,-1,0,1";
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
        }

        [TestMethod]
        public void When_NumberGreaterThan1000Used_Expect_SumIgnoringNumberGreaterThan1000()
        {
            string numbers = "1001,2";
            int expected = 2;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_CustomDelimiterOfAnyLengthUsed_Expect_SumAsInt()
        {
            string numbers = "//***\n1***2***3";
            int expected = 6;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_MultipleDelimetersUsed_Expect_SumAsInt()
        {
            string numbers = "//[*][%]\n1*2%3";
            int expected = 6;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_MultipleDelimetersWithLengthLongerThanOneUsed_Expect_SumAsInt()
        {
            string numbers = "//[***][%%%]\n1***2%%%3";
            int expected = 6;
            Calculator test = new Calculator();
            int actual = test.Add(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_UsingSubtraction_Expect_DifferenceAsInt()
        {
            string numbers = "10,3,2";
            char operand = '-';
            int expected = 5;
            Calculator test = new Calculator();
            int actual = test.Add(numbers, operand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_UsingMultilpication_Expect_ProductAsInt()
        {
            string numbers = "2,3,4";
            char operand = '*';
            int expected = 24;
            Calculator test = new Calculator();
            int actual = test.Add(numbers, operand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_UsingDivision_Expect_QuotientAsInt()
        {
            string numbers = "12,3,2";
            char operand = '/';
            int expected = 2;
            Calculator test = new Calculator();
            int actual = test.Add(numbers, operand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void When_DividingBy0_Expect_Undefined()
        {
            string numbers = "0,5";
            char operand = '/';
            Calculator test = new Calculator();
            int actual = test.Add(numbers, operand);
        }
    }
}
