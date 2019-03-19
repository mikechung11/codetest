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
                String[] stringArr = SplitNumbers(numbers);
                int[] intArr = Array.ConvertAll(stringArr, int.Parse);
                sum = intArr.Sum();
            }
            return sum;
        }

        private string[] SplitNumbers(string numbers)
        {
            string pattern = "[\n,]";
            String[] elements = Regex.Split(numbers, pattern);
            return elements;
        }
    }
}
