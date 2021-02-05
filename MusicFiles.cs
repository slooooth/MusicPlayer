using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MusicPlayer
{
    //class or file for all things relating to local files
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
            try
            {
                XDocument xtest = XDocument.Load(Program.MainFilePath);
            }
            catch (XmlException)
            {
                XMLFail();
            }
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
            try
            {
                XDocument xtest =  XDocument.Load(Program.MainFilePath);
            }
            catch
            {
                XMLFail();
            }
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
                case "add":
                    xdoc.XPathSelectElement("MusicPlayerData/Library").Add(new XElement("Track", new XElement("name", "testname"), new XElement("path", "c:")));
                    SaveXML(xdoc);
                    break;
                case "del":
                    break;
                case "getpath":
                    //I know this is a janky way to do this and there is probably a far better way, but it works for now
                    var path = xdoc.XPathSelectElement("MusicPlayerData/Library").Attribute("path").ToString();
                    string[] printPath = path.Split("\"");
                    Console.WriteLine(printPath[1]);
                    SaveXML(xdoc);
                    break;
                case "setpath":
                    if(InputHandler.ValidDirectory(actions[1]) == true)
                    {
                        xdoc.XPathSelectElement("MusicPlayerData/Library").Attribute("path").Value = actions[1];
                        Console.WriteLine($"library path was set to {actions[1]}");
                        SaveXML(xdoc);
                    }
                    else if (InputHandler.ValidDirectory(actions[1]) == false)
                    {
                        Console.WriteLine("that's not a valid directory");
                    }
                    else
                    {
                        Console.WriteLine("an unknown error occured");
                    }
                    break;
            }
        }

        public static void MainFileManager(string[] args) //function used for things relating to the location of the main file
        {
            switch(args[0])
            {
                case "set":
                    try
                    {
                        if(File.Exists(args[1]) == true && Path.GetExtension(args[1]) == ".xml")
                        {
                            Console.WriteLine("Warning! Using an invalid XML file may cause MusicPlayer to become unstable!");
                            Console.WriteLine("Please use a MusicPlayer-created XML file");
                            Console.WriteLine("Are you sure you want to continue? y/n");
                            string answer = Console.ReadLine();
                            if(answer.ToLower() == "y")
                            {
                                Program.MainFilePath = args[1];
                                Console.WriteLine($"Main file changed to {args[1]}");
                            }
                            else
                            {
                                Console.WriteLine("main file switch aborted");
                            }
                        }
                        else
                        {
                            string TestPath;
                            TestPath = Path.Combine(args[1], "main.xml");
                            if(File.Exists(TestPath) == true)
                            {
                                Console.WriteLine($"A possible file was found at {TestPath}");
                                Console.WriteLine($"would you like to use it? y/n");
                                string check = Console.ReadLine();
                                if(check.ToLower() == "y")
                                {
                                    Console.WriteLine("Warning! Using an invalid XML file may cause MusicPlayer to become unstable!");
                                    Console.WriteLine("Please use a MusicPlayer-created XML file");
                                    Console.WriteLine("Are you sure you want to continue? y/n");
                                    string answer = Console.ReadLine();
                                    if(answer.ToLower() == "y")
                                    {
                                        Program.MainFilePath = TestPath;
                                        Console.WriteLine($"Main file was set to {TestPath}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("main file switch aborted");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("please try again");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("A path is required");
                    }
                    break;
            }
        }

        public static void BackupMain(string[] actions) //function to make a backup copy of a main file
        {
            string MainFileDir = Path.GetDirectoryName(Program.MainFilePath);
            string savingPath = Path.Combine(MainFileDir, "main_backup.xml"); 
            if(actions[0] == "")
            {
                try
                {
                    File.Copy(Program.MainFilePath, savingPath);
                    Console.WriteLine($"File backed up successfully at {savingPath}"); 
                }
                catch(IOException)
                {
                    Console.WriteLine($"the file {savingPath} already exists");
                    Console.WriteLine("Would you like to replace it?");
                    string answer = Console.ReadLine();
                    if(answer.ToLower() == "y")
                    {
                        File.Copy(Program.MainFilePath, savingPath, true);
                        Console.WriteLine($"File backed up successfully at {savingPath}");
                    }
                    else
                    {
                        Console.WriteLine("File was not overwritten");
                    }
                }
            }
            else
            {
                if(Directory.Exists(actions[0]) == true)
                {
                    savingPath = Path.Combine(actions[0], "main_backup.xml");
                    if(File.Exists(savingPath) == true)
                    {
                        Console.WriteLine($"The file {savingPath} already exists. Would you like to overwrite it? (y/n)");
                        string answer = Console.ReadLine();
                        if(answer == "y")
                        {
                            File.Copy(Program.MainFilePath, savingPath, true);
                            Console.WriteLine($"File backed up successfully at {savingPath}");
                        }
                        else
                        {
                            Console.WriteLine("File was not overwritten");
                        }
                    }
                    else
                    {
                        File.Copy(Program.MainFilePath, savingPath);
                        Console.WriteLine($"File backed up successfully at {savingPath}");
                    }
                }
                else
                {
                    Console.WriteLine("Input path was not a valid path");
                }
            }
            return;
        }

        public static void SaveXML(XDocument xdoc)
        {
            xdoc.Save(Program.MainFilePath);
            InputHandler.GetInput();
        }

        public static void XMLFail()
        {
            Console.WriteLine("Warning: XML failure");
            Console.WriteLine("Your XML File might be corrupt");
            Console.WriteLine("Please run MusicPlayerRepair");
            Console.WriteLine("Press any key to exit MusicPlayer.....");
            Console.ReadKey();
            Environment.Exit(3);
        }
    }
}
