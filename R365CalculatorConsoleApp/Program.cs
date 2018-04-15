using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("//;\n-1;-2;3");
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {
            //Custom Delimeter
            var delimStart = text[0].Split('\n').First();
            char[] delimOption = delimStart.Split('/').Last().ToCharArray();
            //Default Delimeters
            char[] defaultDelimiterChars = { '\n', '/' };
            var delimList = new List<char>();
            delimList.AddRange(delimOption);
            delimList.AddRange(defaultDelimiterChars);
            //Delimeter character List
            char[] finalDelim = delimList.ToArray();
            
            List<int> numbers = new List<int>();
            var sum = 0;
            List<int> negativeNumbers = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                string[] words = text[i].Split(finalDelim);

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
