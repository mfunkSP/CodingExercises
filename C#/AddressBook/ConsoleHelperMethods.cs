using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleAddressBook
{
    static class ConsoleHelperMethods
    {
        internal static string PromptForInput(string promptString, string fieldName, bool needValidInput = false)
        {
            Console.Write(promptString + fieldName + ": ");
            var input = Console.ReadLine();
            if (needValidInput)
            {
                while (input.Length == 0 || input == Environment.NewLine)
                {
                    Console.WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fieldName) + " cannot be blank. ");
                    Console.Write(promptString + " " + fieldName + ": ");
                    input = Console.ReadLine();
                }

            }
            return input;
        }
        public static int PromptForNumericInput(string promptString, bool needValidInput = true)
        {
            Console.Write(promptString);
            var input = Console.ReadLine();
            if (needValidInput)
            {
                while (Regex.IsMatch(input, @"\D"))
                {
                    Console.WriteLine("{0} is not a valid selection.", input);
                    Console.Write(promptString);
                    input = Console.ReadLine();
                }
            }
            return Convert.ToInt32(input);
        }
    }
}
