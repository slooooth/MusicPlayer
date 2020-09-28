using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MusicPlayer
{
    class MusicFiles
    {
        public static List<string> GetMusicFiles(string filePath)
        {
            string[] files = (Directory.GetFiles(filePath));
            List<string> musicFiles = new List<string>();
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".wav")
                {
                    musicFiles.Add(file);
                    Console.WriteLine(file);
                }
            }
            return null;
        }
    }
}
