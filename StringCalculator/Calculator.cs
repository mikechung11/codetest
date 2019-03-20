using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly char[] delimiters = { ',', '\n' };
        private readonly char[] trimChars = { '[', ']' };
        private readonly string[] splitDelimiters = { "][" };
        private const string delimiterIdentifier = "//";
        private const char newLine = '\n';

        public int Add(string numbers, char operation = '+')
        {
            int result;
            if (String.IsNullOrEmpty(numbers))
            {
                result = 0;
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
                int[] validNumArr = GetValidNumberArray(intArr);

                result = PerformOperation(operation, validNumArr);
            }
            return result;
        }

        private static int PerformOperation(char operation, int[] validNumArr)
        {
            int result;
            switch (operation)
            {
                case '-':
                    result = validNumArr[0];
                    for (int i = 1; i < validNumArr.Length; i++)
                    {
                        result -= validNumArr[i];
                    }
                    break;
                case '*':
                    result = validNumArr[0];
                    for (int i = 1; i < validNumArr.Length; i++)
                    {
                        result *= validNumArr[i];
                    }
                    break;
                case '/':
                    if (validNumArr.Contains(0))
                    {
                        throw new DivideByZeroException("cannot divide by 0");
                    }
                    result = validNumArr[0];
                    for (int i = 1; i < validNumArr.Length; i++)
                    {
                        result /= validNumArr[i];
                    }
                    break;
                default:
                    result = validNumArr.Sum();
                    break;
            }

            return result;
        }

        private static int[] GetValidNumberArray(int[] intArr)
        {
            if (intArr.Min() < 0)
            {
                int[] negArr = intArr.Where(i => i < 0).ToArray();
                string negStr = string.Join(", ", negArr);
                throw new Exception($"negatives not allowed: {negStr}");
            }
            int[] validNumArr = intArr.Where(i => i <= 1000).ToArray();
            return validNumArr;
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
