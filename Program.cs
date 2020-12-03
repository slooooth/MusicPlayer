using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NAudio.Wave;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MusicPlayer
{
    class Program
    {
        public static string MainFilePath = @"C:\Users\gagnonl\Desktop\main.xml";
        //working on slowly factoring out much of this code. really main should only quickly check for pre-existing libraries, and then hand execution to something else
        static void Main(string[] args)
        {

            //program initialization
            Console.Title = "Music Player";
            Console.WriteLine($"Current date and time: {DateTime.Now}");
            bool MainFileFound = false;
            try
            {
                if (File.Exists(MainFilePath) == false)
                {
                    throw new FileNotFoundException("That file does not exist");
                }
                else
                {
                    Console.WriteLine("Library file found!");
                    MainFileFound = true;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("no library file was found, please enter where one is located, or where you would like a new one to be created");
                while (MainFileFound == false)
                {
                    MainFilePath = InputHandler.GetDirectory();
                    if (File.Exists(MainFilePath) == true)
                    {
                        Console.WriteLine("Library file found!");
                    }
                    else if (Directory.Exists(MainFilePath) == true)
                    {
                        Console.WriteLine($"Attempting to create file at: {MainFilePath}");
                        XDocument test = new XDocument(new XElement("MusicPlayerData", new XElement("Library"), new XElement("Playlists")));
                        try
                        {
                            test.Save(MainFilePath);
                            Console.WriteLine("Library file created successfully");
                            MainFileFound = true;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("This program is not authorized to access that location. Please try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("An unknown error occured");
                        Environment.Exit(2);
                    }
                }
            }
            /*
            Console.WriteLine("no library file was found, please enter where one is located, or where you would like a new one to be created");
            MainFilePath = InputHandler.GetDirectory();
            if (File.Exists(MainFilePath) == true)
            {
                Console.WriteLine("Library file found!");
            }
            else if (Directory.Exists(MainFilePath) == true)
            {
                Console.WriteLine($"Attempting to create file at: {MainFilePath}");
                XDocument test = new XDocument(new XElement("MusicPlayerData", new XElement("Library"), new XElement("Playlists")));
                try
                {
                    test.Save(MainFilePath);
                    Console.WriteLine("Library file created successfully");
                    MainFileFound = true;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("This program is not authorized to access that location. Please try again");
                }
            }
            else
            {
                Console.WriteLine("An unknown error occured");
                Environment.Exit(2);
            }
            8*/
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception. Execution stopping");
                Console.WriteLine(e);
                return;
            }
             
            //MusicFiles.PlaylistManager(new string[] {"new","test2"});
            //end init
            InputHandler.GetInput();
        
        }
    }
}
