using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandlerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Specify pathway to create the directory and sub-directory
            string root = @"D:\Temp";
            string subDir = @"D:\Temp\SubTemp";
            string fileName = @"D:\Temp\SubTemp\TempFile.txt";

            // Creates the directory if not there 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            // Create a sub directory if not there
            if (!Directory.Exists(subDir))
            {
                Directory.CreateDirectory(subDir);
            }

            try
            {
                // Writing new files
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                
                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    string text = "New file " + fileName + " has been created!";
                    byte[] title = new UTF8Encoding(true).GetBytes("Absoulutely new test here. ");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Created by: He-Who-Must-Not-Be-Named ");
                    fs.Write(author, 0, author.Length);
                }

                // Opens the file.txt created above and reads to the console   
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied! You do not have the required clearance to view this file!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found! Please check the path and name again!");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("Drive not found! Please check the path and name again!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found! Please check the path and name again!");
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("You have reached the end of the file! Attempt to read even further is impossible!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Path is too long! Please shorten it!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, not sure what yet though.");
            }

            //Wrting more text to file
            string textSample = "Creating a bunch of new text lines for fun, gibberbish aofahgoawghoarandow";
            File.WriteAllText(fileName,textSample);
            //Reading the file
            string readFile = File.ReadAllText(fileName);
            Console.WriteLine(readFile);

            Console.ReadLine();
        }
    }
}
