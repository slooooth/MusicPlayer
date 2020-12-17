using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MusicPlayer
{
    class MusicFiles
    {
        public static List<string> q = new List<string>();
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

        public static bool GetMainFile(string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);
            foreach(string file in files)
            {
                if(Path.GetFileName(file) == "main.xml")
                {
                    return true;
                }
            }
            return false;
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
                        SaveXML(xdoc);
                    }
                    break;
                case "del":
                    if(xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}']") != null)
                    {
                        Console.WriteLine($"are you sure you want to delete {playlistName}? (y/n)");
                        string ans = Console.ReadLine().ToLower();
                        if(ans == "y")
                        {
                            xdoc.XPathSelectElement($"MusicPlayerData/Playlists/Playlist[@name='{playlistName}']").Remove();
                            Console.WriteLine($"Playlist \"{playlistName}\" was deleted");
                            SaveXML(xdoc);
                        }
                        else
                        {
                            Console.WriteLine("Delete cancelled");
                            SaveXML(xdoc);
                        }

                    }
                    else
                    {
                        Console.WriteLine("That playlist does not exist");
                        SaveXML(xdoc);
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
        }

        public static void LibraryManager(string[] actions)
        {
            XDocument xdoc =  XDocument.Load(Program.MainFilePath);
            switch(actions[0])
            {
                case "get":
                    if(Directory.Exists(Program.MainFilePath) == false)
                    {
                        GetMusicFiles(actions[1]);
                    }
                    else
                    {
                        Console.WriteLine("this option does not allow arguments");
                        SaveXML(xdoc);
                    }
                    break;
            }
        }

        public static void SaveXML(XDocument xdoc)
        {
            xdoc.Save(Program.MainFilePath);
            InputHandler.GetInput();
        }
    }
}
