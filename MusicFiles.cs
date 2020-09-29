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
            //NOTE: currently bugged. Last console line written will display a weird....reference? although it does not seem to be included in the list
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
            return musicFiles;

        }
    }
}
