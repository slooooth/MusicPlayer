using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace MusicPlayer
{
    class MusicFiles
    {
        //gets all the files from a requested directory
        public static List<string> GetMusicFiles(string filePath)
        {
            //NOTE: currently bugged. Last console line written will display a weird....reference? although it does not seem to be included in the list
            string[] files = (Directory.GetFiles(filePath));
            List<string> musicFiles = new List<string>();

            //testing code - I think a for loop would be more efficent here
            int x = 1;
            foreach (string file in files)
            {
                //checking if the currently referenced file is a wav or an mp3
                if (Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".wav")
                {
                    //if the currently referenced file is a music file, add the file to the list and write it to the console
                    musicFiles.Add(file);
                    Console.WriteLine(x + "." + file);
                    x = x + 1;
                }
            }
            if (musicFiles.Count == 0)
            {
                Console.WriteLine("No music files found");
            }
            return musicFiles;

        }

        //function that can be called to work with playlists residing in XML file (unfinished)
        public static void PlaylistManager(string[] actions)
        {
            string playlistName = actions[1];
            switch(actions[0])
            {
                case "new":
                    break;
                case "del":
                    break;
                case "add":
                    break; 
                case "rm":
                    break;
            }
        }
    }
}
