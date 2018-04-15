using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("\t1,2");
            Console.WriteLine(input);
            Console.ReadLine();
        }

        public static int Add(string text)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            List<int> numbers = new List<int>();
            string[] words = text.Split(delimiterChars);
            foreach (var word in words)
            {
                if (word != "")
                {
                    int stringToInt = Convert.ToInt32(word);
                    numbers.Add(stringToInt);
                }
            }
            int sum = numbers.Sum();
            return sum;
        }
    }
}
