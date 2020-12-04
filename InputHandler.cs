﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

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
                                break;
                            case "list":
                                Console.WriteLine("library - lists all tracks availible");
                                Console.WriteLine("play - plays a track");
                                Console.WriteLine("playlist - groups of tracks that can be played");
                                Console.WriteLine("stop - stops the currently playing track");
                                Console.WriteLine("use \"help [option]\" to learn more about an option");
                                Console.WriteLine("quit - closes MusicPlayer");
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
                        Console.WriteLine("Get Directory halted. Execution stopping.");
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
