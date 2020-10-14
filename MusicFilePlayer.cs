using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class MusicFilePlayer
    {
        public static WaveOutEvent waveOut = new WaveOutEvent();

        //will play a requested MP3 file
        public static void PlayMP3File(string file)
        {
            var mp3Reader = new Mp3FileReader(file);
            waveOut.Init(mp3Reader);
            waveOut.Play();
            //Console.ReadLine();
            while(mp3Reader.CurrentTime != mp3Reader.TotalTime)
            {
                Console.SetCursorPosition(0);
                Console.Write(mp3Reader.CurrentTime + " / " + mp3Reader.TotalTime);
            }
            Console.WriteLine("finished");
            waveOut.Stop();
        

        }

        //WIP: will play a requested WAV file
        public static void PlayWAVFile(string file)
        { 
            var wavReader = new WaveFileReader(file);
            waveOut.Init(wavReader);
            waveOut.Play();
            while(wavReader.CurrentTime != wavReader.TotalTime)
            {
                string userInput = InputHandler.GetInput();
                Console.WriteLine(userInput);
                if(userInput != null && userInput != " ")
                {
                    break;
                }
            }
            Console.WriteLine("finished");
            waveOut.Stop();
        }
        
        public static void StopPlaying()
        {
            waveOut.Stop();
        }
    }
}