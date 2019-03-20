using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly char[] delimiters = { ',', '\n' };
        private readonly char[] trimChars = { '[', ']' };
        private readonly string[] splitDelimiters = { "][" };
        private const string delimiterIdentifier = "//";
        private const char newLine = '\n';

        public int Add(string numbers)
        {
            int sum;
            if (String.IsNullOrEmpty(numbers))
            {
                sum = 0;
            }
            else
            {
                String[] stringArr;
                if (numbers.StartsWith(delimiterIdentifier))
                {
                    stringArr = SplitNumbersWithCustomDelimiter(numbers);
                }
                else
                {
                    stringArr = SplitNumbers(numbers);
                }

                int[] intArr = Array.ConvertAll(stringArr, int.Parse);
                if (intArr.Min() < 0)
                {
                    int[] negArr = intArr.Where(i => i < 0).ToArray();
                    string negStr = string.Join(", ", negArr);
                    throw new Exception($"negatives not allowed: {negStr}"); 
                }
                sum = intArr.Where(i => i <= 1000).Sum();
            }
            return sum;
        }

        private string[] SplitNumbersWithCustomDelimiter(string numbers)
        {
            int startIndex = numbers.IndexOf(delimiterIdentifier) + delimiterIdentifier.Length;
            int endIndex = numbers.LastIndexOf(newLine);
            string customDelimStr = numbers.Substring(startIndex, endIndex - startIndex);
            string trimmedDelimGroup = customDelimStr.Trim(trimChars);
            string[] customDelimArr = trimmedDelimGroup.Split(splitDelimiters, StringSplitOptions.None);

            string newNumbers = numbers.Split(newLine)[1];

            string[] elements = newNumbers.Split(customDelimArr, StringSplitOptions.None);
            return elements;
        }

        private string[] SplitNumbers(string numbers)
        {
            string[] elements = numbers.Split(delimiters);
            return elements;
        }
    }
}
