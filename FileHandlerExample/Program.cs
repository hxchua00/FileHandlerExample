using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

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
            //if (!Directory.Exists(root))
            //{
            //    Directory.CreateDirectory(root);
            //}

            // Create a sub directory if not there
            //if (!Directory.Exists(subDir))
            //{
            //    Directory.CreateDirectory(subDir);
            //}

            // Writing new files
            // Check if file already exists. If yes, delete it.     
            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}

            try
            {
                Directory.CreateDirectory(root);
                Directory.CreateDirectory(subDir);

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

                //Wrting more text to file
                string textSample = "Creating a bunch of new text lines for fun, gibberbish aofahgoawghoarandow";
                File.WriteAllText(fileName, textSample);
                //Reading the file
                string readFile = File.ReadAllText(fileName);
                Console.WriteLine(readFile);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied! You do not have the required clearance to view this file! {0}", e.Message);
                Console.WriteLine();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory not found! Please check the path and name again!", e.Message);
                Console.WriteLine();
            }
            catch (DriveNotFoundException e)
            {
                Console.WriteLine("Drive not found! Please check the path and name again!", e.Message);
                Console.WriteLine();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found! Please check the path and name again!", e.Message);
                Console.WriteLine();
            }
            catch (EndOfStreamException e)
            {
                Console.WriteLine("You have reached the end of the file! Attempt to read even further is impossible!", e.Message);
                Console.WriteLine();
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Path is too long! Please shorten it!", e.Message);
                Console.WriteLine();
            }
            catch (IOException e)
            {
                Console.WriteLine($"I/O Error occured! {0}", e.Message);
                Console.WriteLine();
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine($"File type not supported! {0}", e.Message);
                Console.WriteLine();
            }
            catch (SecurityException e)
            {
                Console.WriteLine($"Warning! Security breached! {0}", e.Message);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, not sure what yet though.", e.Message);
            }
            Console.ReadLine();
        }
    }
}
