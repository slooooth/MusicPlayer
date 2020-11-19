using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;

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
            XDocument xdoc = XDocument.Load(Program.MainFilePath);
            switch(actions[0])
            {
                case "new":
                    if(xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}']") != null)
                    {
                        Console.WriteLine("this playlist already exists");
                    }
                    else
                    {
                        xdoc.XPathSelectElement("MusicPlayerData/Playlists").Add(new XElement("Playlist", new XAttribute("name", playlistName)));
                        Console.WriteLine($"Playlist with name {playlistName} was created");
                    }
                    break;
                case "del":
                    try
                    {
                        xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}']");
                        Console.WriteLine($"are you sure you want to delete {playlistName}? (y/n)");
                        string ans = Console.ReadLine().ToLower();
                        if(ans == "y")
                        {
                            xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}'").Remove();
                        }
                        else
                        {
                            Console.WriteLine("Delete cancelled");
                        }

                    }
                    catch
                    {
                        Console.WriteLine("That playlist does not exist");
                    }
                    break;
                case "add":
                    try
                    {
                        /*
                        xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}']")
                        .Add(new XElement("Name"), new XElement(""));
                        */

                    }
                    catch
                    {
                        Console.WriteLine("playlist does not exist. please try again");
                    }
                    break; 
                case "rm":
                    break;
                default:
                    Console.WriteLine("not a vaild option");
                    break;
            }
            xdoc.Save(Program.MainFilePath);
        }
    }
}
