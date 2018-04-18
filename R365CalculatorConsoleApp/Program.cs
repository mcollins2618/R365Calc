﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////[;][%][$]\n4;7%10$14
            var line = Console.ReadLine();
            var input = Add(line);
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {
            //Number Lists
            List<int> numbers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            //Default Delimeters
            char[] defaultDelimCharArray = { '\\', '\n', 'n', '/', ',', ']' }; //*****NEW ADDITION - Changed naming convention to be less confusing - added new default delim
            char[] delimCharArray; //*****NEW ADDITION - Changed naming convention to be less confusing
            var delimList = new List<char>();
            var totalSum = 0;
            if (text[0].Contains("//") && text[0].Contains(@"\n"))
            {
                //Custom Delimeter list creation
                var delimStart = text[0].Split(@"\n").First(); //******NEW ADDITION allows for double \\ on new line console submit
                char[] delimOption = delimStart.Split("//").Last().Distinct().ToArray(); //*****NEW ADDITION - Custom Delim options to be Distinct rather than showing duplicates
                delimList.AddRange(delimOption);
                delimList.AddRange(defaultDelimCharArray);
                //Delimeter character array
                delimCharArray = delimList.ToArray();
            }
            else
            {
                delimCharArray = defaultDelimCharArray;
            }
            //*******NEW ADDTION - REMOVE FOR LOOP as it is not needed
            //Splits the string input to remove any and all delim's
            string[] words = text[0].Split(delimCharArray, StringSplitOptions.RemoveEmptyEntries); //******NEW ADDITION - REMOVE Empty Entries
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
                    Console.WriteLine("There are" + " " + numbers.Count() + " " + "numbers that total:" + " " + totalSum);
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
