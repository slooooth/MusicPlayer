using System;
using System.IO;

namespace MusicPlayer
{
    class InputHandler
    {
        public static void GetInput()
        {
            //splits the string given to the function every time there is a space
            string input = Console.ReadLine();
            string[] splitInput = input.Split(" ");
            string command = splitInput[0].ToLower();
            string[] args = new string[splitInput.Length - 1];
            for(int x = 0; x < (splitInput.Length-1); x++)
            { 
                args[x] = splitInput[x+1].ToLower();
            }
            switch (command)
            {
                case "skip":
                    MusicFilePlayer.SkipTrack();
                    break;

                case "stop":
                    MusicFilePlayer.StopPlaying();
                    break;

                case "play":
                    try
                    {
                        MusicFilePlayer.PlayFile(args[0]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Missing info. Try \"help play\"");
                    }
                    break;

                case "help":
                    if (args.Length == 0)
                    {
                        Console.WriteLine("This is the help menu");
                        Console.WriteLine("usage: command [options] [arguments]");
                        Console.WriteLine("use \"help list\" to get a list of all usable commands");
                        GetInput();
                    }
                    else
                    {
                        switch(args[0].ToLower())
                        {
                            case "stop":
                                Console.WriteLine("Stops the music playing");
                                Console.WriteLine("options: none");
                                break;
                            case "playlist":
                                Console.WriteLine("playlists allow you to group different tracks together");
                                Console.WriteLine("Options:");
                                Console.WriteLine("new - creates a new playlist, args - playlist name to be created");
                                Console.WriteLine("del - deletes a playlist, args - playlist name to remove");
                                Console.WriteLine("add - adds a specified track to a playlist, args - playlist to add track to, path of track to be added");
                                Console.WriteLine("rm - removes a track from a playlist, args - playlist to remove track from, select track to be removed");
                                Console.WriteLine("list - lists all availible playlists, args - none");
                                break;
                            case "play":
                                Console.WriteLine("plays either a given track or a playlist");
                                Console.WriteLine("options:");
                                Console.WriteLine("track - plays a specific track, args - the name of a track in library OR the track file path");
                                Console.WriteLine("playlist - plays a specific playlist, args - track name or number in playlist. If left blank, plays the first song");
                                Console.WriteLine("all - plays all the music in the library, starting from the top, args - none");
                                break;
                            case "library":
                                Console.WriteLine("Works with your music library");
                                Console.WriteLine("Options:");
                                Console.WriteLine("add - adds a track to the library, args - the track's file path");
                                Console.WriteLine("del - deletes a song from the library, args - song ID or name");
                                Console.WriteLine("get - lists all tracks in the library");
                                Console.WriteLine("getpath - lists the path of the library");
                                Console.WriteLine("setpath - sets the path of the library");
                                break;
                            case "list":
                                Console.WriteLine("library - lists all tracks availible");
                                Console.WriteLine("play - plays a track");
                                Console.WriteLine("playlist - groups of tracks that can be played");
                                Console.WriteLine("stop - stops the currently playing track");
                                Console.WriteLine("quit - closes MusicPlayer");
                                Console.WriteLine("clear - clears the console window");
                                Console.WriteLine("path - displays main file path");
                                Console.WriteLine("color - change colors");
                                Console.WriteLine("use \"help [option]\" to learn more about an option");
                                break;
                            case "quit":
                                Console.WriteLine("closes MusicPlayer");
                                Console.WriteLine("options: none");
                                break;
                            case "clear":
                                Console.WriteLine("clear - clears the display console");
                                Console.WriteLine("options: none");
                                break;
                            case "path":
                                Console.WriteLine("path - displays the current main file path");
                                Console.WriteLine("options: none");
                                break;
                            case "color":
                                Console.WriteLine("works with the display colors");
                                Console.WriteLine("options:");
                                Console.WriteLine("text/txt/t - changes text colors");
                                Console.WriteLine("background/bg/back/b - changes background colors");
                                Console.WriteLine("reset/default/clear - resets colors to white text, black background");
                                Console.WriteLine("both bg and txt take one argument of a color");
                                Console.WriteLine("Availible colors are - grey, yellow, red, blue, cyan, white, black, purple, green");
                                break;
                            default:
                                Console.WriteLine("that isn't a valid command");
                                break;
                        }
                    }
                    break;
                case "playlist":
                    try
                    {
                        MusicFiles.PlaylistManager(args);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Missing info. Try \"help playlist\"");
                    }
                    
                    break;
                case "quit":
                    Console.WriteLine("Stopping and closing MusicPlayer");
                    Environment.Exit(0);
                    break;
                case "library":
                    try
                    {
                        MusicFiles.LibraryManager(args);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Missing info. Try \"help library\"");
                    }
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "path":
                    Console.WriteLine(Program.MainFilePath);
                    break;
                case "color":
                    switch(args[0])
                    {
                        case "text":
                            switch(args[1])
                            {
                                case "blue":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Clear();
                                    break;
                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    break;
                                case "green":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Clear();
                                    break;
                                case "purple":
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Clear();
                                    break;
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    break;
                                case "yellow":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Clear();
                                    break;
                                case "white":
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    break;
                                case "grey":
                                case "gray":
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Clear();
                                    break;
                                case "cyan":
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Color is either missing or not availible");
                                    break;
                            }
                            break;
                        case "back":
                        case "background":
                        case "bg":
                            switch (args[1])
                            {
                                case "blue":
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Clear();
                                    break;
                                case "black":
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    break;
                                case "green":
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Clear();
                                    break;
                                case "purple":
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.Clear();
                                    break;
                                case "red":
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    break;
                                case "yellow":
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.Clear();
                                    break;
                                case "white":
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    break;
                                case "grey":
                                case "gray":
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.Clear();
                                    break;
                                case "cyan":
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Color is either missing or not availible");
                                    break;
                            }
                            break;
                        case "default":
                        case "clear":
                        case "reset":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Missing info");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("that's not a valid command - try \"help\" for more information");;
                    break;
          
            }
            GetInput();
        }

        //only should be used for init/setting up a new environment, as execution cannot be stopped until a vaild directory is given
        public static string GetDirectory()
        {
            Console.WriteLine("Please enter a directory: ");
            string inputDirectory = null;
            while(Directory.Exists(inputDirectory) == false && File.Exists(inputDirectory) == false)
            {
                inputDirectory = Console.ReadLine();
                if(Directory.Exists(inputDirectory) == false && File.Exists(inputDirectory) == false)
                {
                    if(inputDirectory.ToLower() == "stop" || inputDirectory.ToLower() == "quit")
                    {
                        Console.WriteLine("MusicPlayer cannot run without a main file");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("not a vaild directory or file on this machine");
                        Console.WriteLine("Please enter a directory or file: ");
                    }
                } 
            }
            return inputDirectory;
        }
    }
}
