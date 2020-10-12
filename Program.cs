using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //just titles the console
            Console.Title = "Music Player";
            //Writes the time and date
            Console.WriteLine("Current date and time:" + " " + DateTime.Now);

            //random path variables for testing writing to a file
            //string path = @"D:\Code Testing Files\";
            //string fileName = "test.txt";
            //string fullPath = path + fileName;
            //File.WriteAllText(fullPath, "test");

            //declares a variable list
            List<string> test = new List<string>();
            
            //attemts to see if a directory exists. if not, program exits
            try 
            {
                test = MusicFiles.GetMusicFiles(@"D:\Downloads");
            }
            //catches an exception where the file path is not vaild
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Not a vaild directory. Please try again");
                return;
            }
            //catches all other exceptions
            catch (Exception x)
            {
                Console.WriteLine("An unanticipated error occured");
                Console.WriteLine("Error: " + x);
                return;
            }


            if (test.Count != 0)
            {
                Console.WriteLine(test);
                int last = test.Count - 1;
                Console.WriteLine(test[last]);
            }
            //testing code
            MusicFilePlayer.PlayMP3File(@"D:\Downloads\Explore This (prod. WISHBOI).mp3");
            Console.ReadLine();
            
        }
    }
}
