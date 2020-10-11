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
            return Console.ReadLine();
        }
        public static void ExecuteInput(string input)
        {
            string[] splitInput = input.Split(" ");
            switch (splitInput[0])
            {
                case "skip":
                    Console.WriteLine("Skip Called");
                    break;

                case "stop":
                    Console.WriteLine("Stop Called");
                    break;


            }
        }
    }
}
