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
    }
}
