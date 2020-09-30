using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class MusicFilePlayer
    {
        public static WaveOutEvent waveOut;
        public static void PlayMP3File(string file)
        {
            using (var mp3Reader = new Mp3FileReader(file))
            {
                waveOut.Init(mp3Reader);
                waveOut.Play();

            }
        }
        public static void PlayWAVFile(string file)
        { 
            using (var wavReader = new WaveFileReader(file))
            {
                waveOut.Init(wavReader);
                waveOut.Play();
            }
        }
    }
}
