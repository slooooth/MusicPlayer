using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class Program
    {
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

            List<string> test = MusicFiles.GetMusicFiles(@"D:\Downloads");
            //calls the function to get all valid music files from a requested directory
            if (test.Count != 0)
            {
                Console.WriteLine(test);
                int last = test.Count - 1;
                Console.WriteLine(test[last]);
            }
            //testing code
            MusicFilePlayer.PlayMP3File(@"D:\Downloads\Explore This (prod. WISHBOI).mp3");
            Console.ReadLine();
            
        }
    }
}
