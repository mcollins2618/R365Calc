using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("//;\n1;2;4;5");
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {

            char[] defaultDelimiterChars = { ' ', ',', '.', ':', '\t', '\n', '/', ';', '[', ']', '*', '%' };
            List<int> numbers = new List<int>();
            var sum = 0;
            List<int> negativeNumbers = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                string[] words = text[i].Split(defaultDelimiterChars);
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        int stringToInt = Convert.ToInt32(word);
                        if (stringToInt < 1000)
                        {
                            if (stringToInt < 0)
                            {
                                negativeNumbers.Add(stringToInt);
                            }
                            else
                            {
                                numbers.Add(stringToInt);
                            }
                        }
                    }
                }
            }
            try
            {
                if (negativeNumbers.Count > 0)
                {
                    throw new System.Exception();
                }
                else
                {
                    sum = numbers.Sum();
                    Console.WriteLine(sum);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Negatives are not allowed!");
                negativeNumbers.ForEach(i => Console.Write("{0}\t", i));
            }

            return sum;




        }
    }
}
