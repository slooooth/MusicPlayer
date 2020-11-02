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
        //will handle all inputs (I think this will help the program take inputs while functions are running/songs are playing)
        public static string GetInput()
        {
            //just returns whatever the user inputs
            return Console.ReadLine();
        }
        public static void ExecuteInput(string input)
        {
            //splits the string given to the function every time there is a space
            string[] splitInput = input.Split(" ");
            string command = splitInput[0];
            string[] args = new string[splitInput.Length - 1];
            for(int x = 0; x <=(splitInput.Length-1); x++)
            {
                args[x] = splitInput[x+1];
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
                    MusicFilePlayer.PlayFile(args[0]);
                    break;

                case "help":
                    if (args.Length == 0)
                    {
                        Console.WriteLine("This is the help menu");
                        Console.WriteLine("usage: command [options] [arguments]");
                    }
                    else
                    {
                        switch(args[0])
                        {
                            case "stop":
                            Console.WriteLine("Stops the music playing");
                            Console.WriteLine("options: none");
                            break;
                            case "playlist":
                            Console.WriteLine("playlists allow you to group different tracks together");
                            Console.WriteLine("Options:");
                            Console.WriteLine("new - creates a new playlist");
                            Console.WriteLine("del - deletes a playlist");
                            Console.WriteLine("add - adds a specified track to a playlist, args - path of track to be added");
                            Console.WriteLine("rm - removes a track from a playlist, args - select track to be removed");
                            break;

                        }
                    }
                    break;

                case "playlist":
                    MusicFiles.PlaylistManager(args);
                    break;
                

            }
        }

        //only should be used for init/setting up a new environment
        public static string GetDirectory()
        {
            Console.WriteLine("Please enter a directory: ");
            string inputDirectory = null;
            while(Directory.Exists(inputDirectory) == false)
            {
                inputDirectory = Console.ReadLine();
                if(Directory.Exists(inputDirectory) == true)
                {
                    return inputDirectory;
                }
                else if(Directory.Exists(inputDirectory) == false)
                {
                    Console.WriteLine("not a vaild directory on this machine");
                    Console.WriteLine("Please enter a directory: ");
                }
                else
                {
                    Console.WriteLine("unknown error occured");
                    Console.WriteLine("Please enter a directory: ");
                }
            }
            return inputDirectory;
        }
    }
}
