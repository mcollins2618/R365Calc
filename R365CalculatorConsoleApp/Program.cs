using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("//[*][%]\n1*2%3");
            Console.WriteLine(input);
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '/', ';', '[', ']', '*', '%' };
            List<int> numbers = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                string[] words = text[i].Split(delimiterChars);
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        int stringToInt = Convert.ToInt32(word);

                        try
                        {
                            if (stringToInt < 0)
                            {
                                throw new System.Exception();
                            }

                            else
                            {
                                numbers.Add(stringToInt);
                            }
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("Negatives not allowed!");
                            Console.WriteLine(word);
                        }
                    }

                }
            }

            int sum = numbers.Sum();
            return sum;
        }
    }
}
