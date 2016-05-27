using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple unit tests for FileReadAndOutputNthLine(). Ideally, these unit tests should be 
            //written using a unit testing framework and Assert statements.
            FileReadAndOutputNthLine(@"C:/tmp/Hello.txt", 4);
            FileReadAndOutputNthLine(@"C:/tmp/Hello.txt", 7);
            FileReadAndOutputNthLine(@"C:/tmp/Hello.txt", -1);
            FileReadAndOutputNthLine(@"C:/tmp/Hello.txt", 100);
            FileReadAndOutputNthLine(@"C:/tmp/Hello1.txt", 7);

            Console.Read();
        }

        /// <summary>
        /// Function to read a file and display the Nth line
        /// </summary>
        /// <param name="pathToFile"> The path to the file </param>
        /// <param name="number"> The number of line that needs to be displayed </param>
        static void FileReadAndOutputNthLine(string pathToFile, int number) {
            if (number < 0)
            {
                Console.WriteLine("Error: Cannot display line with negative line number");
                return;
            }
            if (String.IsNullOrEmpty(pathToFile))
            {
                Console.WriteLine("Error: The path to file is empty");
                return;
            }

            try
            {
                int counter = 0;
                string line;

                //Read file from the path and read one line at a time
                System.IO.StreamReader fileToRead = new System.IO.StreamReader(pathToFile);
                while((line = fileToRead.ReadLine()) != null)
                {
                    //If we have reached the required line display and return
                    if (number == (counter+1))
                    {
                        System.Console.WriteLine(line);
                        return;
                    }
                    counter++;
                }

                Console.WriteLine("Error: The input file has less than " + number + " of lines");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Exception while reading the file. Exception message - " + e.Message);
            }
            
        }

    }
}
