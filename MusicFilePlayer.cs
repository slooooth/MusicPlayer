using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class MusicFilePlayer
    {
        //will play a requested MP3 file
        public static void PlayMP3File(string file)
        {
            var mp3Reader = new Mp3FileReader(file);
            var waveOut = new WaveOutEvent();
            waveOut.Init(mp3Reader);
            waveOut.Play();
            //Console.ReadLine();
            while(mp3Reader.CurrentTime != mp3Reader.TotalTime)
            {
                if(InputHandler.GetInput() != null)
                {
                    break;
                }
            }
            Console.WriteLine("finished");
            waveOut.Stop();
        

        }

        //WIP: will play a requested WAV file
        public static void PlayWAVFile(string file)
        { 
            using (var wavReader = new WaveFileReader(file))
            {
                var waveOut = new WaveOutEvent();
                waveOut.Init(wavReader);
                waveOut.Play();
            }
        }
    }
}
