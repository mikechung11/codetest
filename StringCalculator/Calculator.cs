using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
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
                if (numbers.StartsWith("//"))
                {
                    (string delimiter, string newNumbers) = GetDelimiter(numbers);
                    stringArr = SplitNumbers(newNumbers, delimiter);
                }
                else
                {
                    stringArr = SplitNumbers(numbers);
                }

                int[] intArr = Array.ConvertAll(stringArr, int.Parse);
                if (intArr.Min() < 0)
                {
                    int[] negativeArr = intArr.Where(i => i < 0).ToArray();
                    string negatives = string.Join(", ", negativeArr);
                    throw new Exception($"negatives not allowed: {negatives}"); 
                }
                sum = intArr.Sum();
            }
            return sum;
        }

        private (string delimiter, string newNumbers) GetDelimiter(string numbers)
        {
            int startIndex = numbers.IndexOf("//") + "//".Length;
            int endIndex = numbers.LastIndexOf("\n");
            string delimiter = numbers.Substring(startIndex, endIndex - startIndex);

            string newNumbers = Regex.Split(numbers, "\n")[1];

            return (delimiter, newNumbers);
        }

        private string[] SplitNumbers(string numbers, string pattern = "[\n,]")
        {
            String[] elements = Regex.Split(numbers, pattern);
            return elements;
        }
    }
}
