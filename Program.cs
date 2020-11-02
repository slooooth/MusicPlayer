using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;
using System.Xml;
using System.Xml.Linq;

namespace MusicPlayer
{
    class Program
    {
        public static string MainFilePath = @"C:\Users\gagnonl\Desktop\helpme.xml"; 
        //working on slowly factoring out much of this code. really main should only quickly check for pre-existing libraries, and then hand execution to something else
        static void Main(string[] args)
        {
            try
            {
                if(File.Exists(MainFilePath) == false)
                {
                    throw new FileNotFoundException("That file does not exist");
                }
                Console.WriteLine("file found");
            }
            catch (FileNotFoundException)
            {
                
                //File.Create(MainFilePath);
                Console.WriteLine("file created");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception. Execution stopping");
                Console.WriteLine(e);
                return;
            }
            /*
            Console.WriteLine("<TESTING>");
            XDocument tester = XDocument.Load(MainFilePath);
            IEnumerable<XElement> employees = tester.Root.Elements();
            Console.WriteLine("Employee Names: ");
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Element("Name").Value);
            }
            Console.WriteLine("</TESTING>");
            */




            //basic console setup
            Console.Title = "Music Player";
            Console.WriteLine("Current date and time:" + " " + DateTime.Now);

            //random path variables for testing writing to a file
            //string path = @"D:\Code Testing Files\";
            //string fileName = "test.txt";
            //string fullPath = path + fileName;
            //File.WriteAllText(fullPath, "test");

            MusicFiles.GetMusicFiles(InputHandler.GetDirectory());
            //attempt to play a file (It's on my local PC so likely won't exist on other machines)
            try
            {
                MusicFilePlayer.PlayMP3File(@"D:\Downloads\Explore This (prod. WISHBOI).mp3");
            }
            catch
            {
                Console.WriteLine("Not a valid directory");
            }
            Console.ReadLine();
        
        }
    }
}
