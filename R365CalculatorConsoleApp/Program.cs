using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace R365CalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var line = "//[;][,][#][$][&][:]\n9;7$14;1087,19:16";
            var line2 = "//[;][,][%][$][&][:]\n4;32$3;1014:1";
            var line3 = "//;\n1;98;21;7";
            var line4 = "//[***]\n1***2***3";
            var line5 = "//[*][%]\n1*2%3";
            Add(line, line2, line3, line4, line5);
            Console.ReadLine();
        }

        public static int Add(params string[] text)
        {
            //Number Lists
            List<int> numbers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            List<string> illegalFormatList = new List<string>();
            char[] defaultDelimCharArray = { '\\', '\n', 'n', '/', ',' }; //*****NEW ADDITION - Changed naming convention to be less confusing - edited default delims
            char[] delimCharArray; //*****NEW ADDITION - Changed naming convention to be less confusing
            var delimList = new List<char>();
            var totalSum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                var delimStart = text[i].Split("\n").First(); //******NEW ADDITION allows for double \\ on new line console submit
                bool delimContainsIllegalChar = delimStart.Any(char.IsDigit) || delimStart.Any(char.IsLetter);//******NEW ADDITION Check to see if delimeters contain integer
                if (delimContainsIllegalChar == true && text[i].Contains("\n"))
                {
                    illegalFormatList.Add(text[i]);
                }
                else
                {
                    if (text[i].Contains("//") && text[i].Contains("\n"))
                    {
                        //Custom Delimeter list creation
                        //var delimStart = text[0].Split(@"\n").First(); //******NEW ADDITION allows for double \\ on new line console submit
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
                    string[] words = text[i].Split(delimCharArray, StringSplitOptions.RemoveEmptyEntries); //******NEW ADDITION - REMOVE Empty Entries
                    foreach (var word in words)
                    {
                        //*****NEW ADDITION - REMOVED if statement as it is not needed with the empty string removal
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
            try
            {
                if (illegalFormatList.Count > 0)
                {
                    throw new FormatException();
                }
                else if (negativeNumbers.Count > 0)
                {
                    throw new Exception();
                }
                else
                {
                    totalSum = numbers.Sum();
                    Console.WriteLine("There are" + " " + numbers.Count() + " " + "numbers that total:" + " " + totalSum);
                }
            }
            //Try Catch for Format Exception (Example - 1,\n)
            catch (FormatException)
            {
                Console.WriteLine("Please use the correct format.");
                illegalFormatList.ForEach(x => Console.Write(Regex.Replace(x, @"\t|\n|\r", "") + " " + "is not allowed.\n"));
            }
            //Try Catch that will throw exception when a negative number is found. 
            //If no negatives are found - totalSum will calculate and be displayed.
            catch (Exception)
            {
                Console.WriteLine("Negatives are not allowed!");
                negativeNumbers.ForEach(x => Console.Write("{0}\t", x));
            }

            return totalSum;

        }
    }
}
