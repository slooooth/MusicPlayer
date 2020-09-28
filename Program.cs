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
            Console.Title = "Music Player";
            /* Is able to get all vaild music files from a requested directory
            string something = Console.ReadLine();
            string[] files = (Directory.GetFiles(something));
            List<string> musicFiles = new List<string>();
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".wav")
                {
                    musicFiles.Add(file);
                    Console.WriteLine(file);
                }
            }
            */

            string path = @"D:\Code Testing Files\";
            string fileName = "test.txt";
            string fullPath = path + fileName;
            File.WriteAllText(fullPath, "test");
            MusicFiles.GetMusicFiles("thing");

        }
    }
}
