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
        public static string MainFilePath = @"C:\Users\gagnonl\Desktop\test.xml"; 
        //working on slowly factoring out much of this code. really main should only quickly check for pre-existing libraries, and then hand execution to something else
        static void Main(string[] args)
        {
            XDocument tester = XDocument.Load(MainFilePath);
            IEnumerable<XElement> employees = tester.Root.Elements();
            Console.WriteLine("Employee Names: ");
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Element("Name").Value);
            }




            //just titles the console
            Console.Title = "Music Player";
            //Writes the time and date
            Console.WriteLine("Current date and time:" + " " + DateTime.Now);

            //random path variables for testing writing to a file
            //string path = @"D:\Code Testing Files\";
            //string fileName = "test.txt";
            //string fullPath = path + fileName;
            //File.WriteAllText(fullPath, "test");

            MusicFiles.GetMusicFiles(InputHandler.GetDirectory());
            //testing code
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
