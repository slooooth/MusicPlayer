using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //just titles the console
            Console.Title = "Music Player";

            //random path variables for testing writing to a file
            string path = @"D:\Code Testing Files\";
            string fileName = "test.txt";
            string fullPath = path + fileName;
            File.WriteAllText(fullPath, "test");

            //calls the function to get all valid music files from a requested directory (also a test with classes)
            List<string> test = MusicFiles.GetMusicFiles(@"D:\Downloads");
            //testing code
            Console.WriteLine(test);
            int last = test.Count - 1;
            Console.WriteLine(test[last]);
            Console.ReadLine();
        }
    }
}
