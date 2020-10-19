using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class Program
    {
        //working on slowly factoring out much of this code. really main should only quickly check for pre-existing libraries, and then hand execution to something else
        static void Main(string[] args)
        {
            //just titles the console
            Console.Title = "Music Player";
            //Writes the time and date
            Console.WriteLine("Current date and time:" + " " + DateTime.Now);

            //random path variables for testing writing to a file
            //string path = @"D:\Code Testing Files\";
            //string fileName = "test.txt";
            //string fullPath = path + fileName;
            //File.WriteAllText(fullPath, "test");

            InputHandler.GetDirectory();
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
