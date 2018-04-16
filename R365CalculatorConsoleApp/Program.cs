﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Add("//[;]\n1;2;3");
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {
            //Number Lists
            List<int> numbers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            //Default Delimeters
            char[] defaultDelimiterChars = { '\n', '/', ',', ']' };
            char[] charList;
            var delimList = new List<char>();
            var totalSum = 0;
            if (text[0].Contains("/"))
            {
                //Custom Delimeter list creation
                var delimStart = text[0].Split('\n').First();
                char[] delimOption = delimStart.Split('/').Last().ToCharArray();
                delimList.AddRange(delimOption);
                delimList.AddRange(defaultDelimiterChars);
                //Delimeter character array
                charList = delimList.ToArray();
            }
            else
            {
                charList = defaultDelimiterChars;
            }
            for (int i = 0; i < text.Length; i++)
            {
                //Splits the string input to remove any and all delim's
                string[] words = text[i].Split(charList);
                foreach (var word in words)
                {
                    if (word != "")
                    {
                        int stringToInt = Convert.ToInt32(word);
                        //Check and ignore any converted int that is above 1000
                        if (stringToInt < 1000)
                        {
                            //Negative Number check. Will add any negative numbers to list which will trigger exception
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
            //Try Catch that will throw exception when a negative number is found. 
            //If no negatives are found - totalSum will calculate and be displayed.
            try
            {
                if (negativeNumbers.Count > 0)
                {
                    throw new Exception();
                }
                else
                {
                    totalSum = numbers.Sum();
                    Console.WriteLine("Total:" + " " + totalSum);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Negatives are not allowed!");
                negativeNumbers.ForEach(i => Console.Write("{0}\t", i));
            }

            return totalSum;

        }
    }
}
