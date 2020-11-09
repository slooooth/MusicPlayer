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
        public static string MainFilePath = @"C:\Users\gagnonl\Desktop\test12.xml"; 
        //working on slowly factoring out much of this code. really main should only quickly check for pre-existing libraries, and then hand execution to something else
        static void Main(string[] args)
        {

            //<XML testing>
            try
            {
                if(File.Exists(MainFilePath) == false)
                {
                    throw new FileNotFoundException("That file does not exist");
                }
                else
                {
                    Console.WriteLine("file found");
                } 
            }
            catch (FileNotFoundException)
            {
                
                //File.Create(MainFilePath);
                Console.WriteLine("file created");
                XDocument test = new XDocument(
                    new XElement("MusicPlayerData", new XElement("Library"), new XElement("Playlists"))
                );
                test.Save(MainFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception. Execution stopping");
                Console.WriteLine(e);
                return;
            }
            //</XML testing>

            XDocument test2 = XDocument.Load(MainFilePath);
            //test2.Load(MainFilePath);
            test2.XPathSelectElement("MusicPlayerData/Playlists").Add(new XElement("test"));
            test2.Save(MainFilePath);


            //basic console setup
            Console.Title = "Music Player";
            Console.WriteLine("Current date and time:" + " " + DateTime.Now);

            MusicFiles.GetMusicFiles(InputHandler.GetDirectory());
            //attempt to play a file (It's on my local PC so likely won't exist on other machines)
            try
            {
                MusicFilePlayer.PlayMP3File(@"D:\Downloads\Explore This (prod. WISHBOI).mp3");
            }
            catch
            {
                Console.WriteLine("Not a valid directory");
            }
            Console.ReadLine();
        
        }
    }
}
