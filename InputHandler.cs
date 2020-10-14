using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            switch (splitInput[0])
            {
                //
                case "skip":
                    Console.WriteLine("Skip Called");
                    break;

                case "stop":
                    MusicFilePlayer.StopPlaying();
                    break;
                case "play":
                    MusicFilePlayer.PlayFile(splitInput[1]);
                    break;
                case "help":
                
                    break;

            }
        }

        //only should be used for init/setting up a new environment
        public static string GetDirectory()
        {
            Console.WriteLine("Please enter a directory: ");
            string inputDirectory = Console.ReadLine();
            if(Directory.Exists(inputDirectory) == true)
            {
                return inputDirectory;
            }
            else if(Directory.Exists(inputDirectory) == false)
            {
                Console.WriteLine("not a vaild directory on this machine");
                GetDirectory();
                return null;
            }
            else
            {
                Console.WriteLine("unknown error occured");
                GetDirectory();
                return null;
            }
        }
    }
}
