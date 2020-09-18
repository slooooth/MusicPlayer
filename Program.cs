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
            Console.Title = "Music Player";
            //WriteLine("Please enter a directory for your songs");
            //string songDir = ReadLine();
            /*
            var testLocation = @"D:\Downloads\[ontiva.com] Starbound Soundtrack - Menu Theme-tiny.wav";
            var mp3Player = new Mp3FileReader(@"D:\Downloads\Tristam - Bone Dry [Monstercat Release].mp3");
            var wavReader = new WaveFileReader(@"D:\Downloads\[ontiva.com] Starbound Soundtrack - Menu Theme-tiny.wav");
            var flacReader = new AudioFileReader(@"D:\Downloads\Tristam - Bone Dry [Monstercat Release].mp3");
            var mp3Player2 = new WaveFileReader(testLocation);
            List<int> four = new List<int>();
            var waveOut = new WaveOutEvent();
            waveOut.Init(mp3Player2);
            waveOut.Play();
            Console.ReadLine();
            */
            string[] fileNames = (Directory.GetFiles(@"D:\LMMS"));
            Console.WriteLine(fileNames[0]);
            foreach(string file in fileNames)
            {
                Console.WriteLine(file);
            }

        }
    }
}
