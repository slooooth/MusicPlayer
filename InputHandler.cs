using System;
using System.Collections.Generic;
using System.Text;

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


            }
        }
    }
}
