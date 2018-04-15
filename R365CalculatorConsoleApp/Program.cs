using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("1,1,1,1,1,1,1,1,1,1");
            Console.WriteLine(input);
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n' };
            List<int> numbers = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                string[] words = text[i].Split(delimiterChars);
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        int stringToInt = Convert.ToInt32(word);
                        numbers.Add(stringToInt);
                    }
                }
            }

            int sum = numbers.Sum();
            return sum;
        }
    }
}
