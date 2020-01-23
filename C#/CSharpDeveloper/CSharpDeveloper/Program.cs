/*
 * 1.  Fix the compiler errors so that the solution builds without error.
 * 2.  Add all lines from the text file to a new collection.
 * 3.  From the collection you created in step #2, select all the lines that end in "th" into a new collection (USE A CASE-INSENSITIVE COMPARISON)
 * 4.  Output the lines ending in "th" to the console, sorted alphabetically, keep the output displayed until the user presses a key.
 * 5.  Move the file path string to a new appSetting value in the app.config file and retrieve them from there instead of having it defined in code.
 * 
 * Extra credit...
 * 
 * 1.  Define a new appSetting value that is a regular expression pattern and use that as the match criteria (ends in th, case-insensitive)
 * 2.  Implement "using" block(s) to ensure that any objects that implement the IDisposable interface are disposed of when they are no longer needed.
 */

namespace ScriptPro.Exercises.CSharpDeveloper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private string filePath = "..\..\Data\LastNames.txt";

        static void Main(string[] args)
        {
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(fs);

            string line = default(string);

            while (NULL != (line = sr.ReadLine()))
            {
                Console.WriteLine(line);
            }
        }
    }
}
