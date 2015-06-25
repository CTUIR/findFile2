using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findFile2
{
    class Program
    {
        private static string fileToLocate = null;
        
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("We are searching for this file:  " + args[0]);
                fileToLocate = args[0].ToLower();

                string currentFolder = Directory.GetCurrentDirectory();

                ProcessDirectory(currentFolder);
            }
            else
            {
                Console.WriteLine("No file name entered...");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // First, process all files in the directory passed in.
        // Second, recurse on any directories that are found, doing files first, and then directories.
        public static void ProcessDirectory(string targetDirectory)
        {
            string currentFolder = Directory.GetCurrentDirectory();
            
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string aFileName)
        {
            //Console.WriteLine(aFileName);
            int lastSlashLocation = aFileName.LastIndexOf("\\");
            string thePath = aFileName.Substring(0, lastSlashLocation);
            string theFileWithCase = aFileName.Substring(lastSlashLocation + 1);
            string theFileLowerCase = theFileWithCase.ToLower();
            //Console.WriteLine(theFile);

            if (theFileLowerCase.Equals(fileToLocate))
            {
                string theLocation = thePath;
                //string theResult = "Found " + theFileWithCase + " at:  ";
                //Console.WriteLine(theResult + theLocation);
                Console.WriteLine(theLocation);
                //Console.WriteLine("Processed file '{0}'.", path);
            }
        }
    }
}
