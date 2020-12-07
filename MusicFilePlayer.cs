using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NAudio.Wave;

namespace MusicPlayer
{
    class MusicFilePlayer
    {
        //static reference to the output device on the machine
        public static WaveOutEvent waveOut = new WaveOutEvent();

        //will play a requested MP3 file
        public static void PlayMP3File(string file)
        {
            var mp3Reader = new Mp3FileReader(file);
            waveOut.Init(mp3Reader);
            waveOut.Play();
            //Console.ReadLine();
            double lastPercentComplete = 0;
            while (mp3Reader.CurrentTime != mp3Reader.TotalTime)
            {
                //ms version
                //Console.Write($"{mp3Reader.CurrentTime}ms / {mp3Reader.TotalTime}ms");

                //percentage version
                double percentComplete = Math.Round((mp3Reader.CurrentTime/mp3Reader.TotalTime)*100, 0);
                if(percentComplete != lastPercentComplete)
                {
                    lastPercentComplete = percentComplete;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(percentComplete + "%");
                }
                
            }
            Console.WriteLine("finished");
            waveOut.Stop();
        

        }

        //will play a requested WAV file (untested)
        public static void PlayWAVFile(string file)
        { 
            var wavReader = new WaveFileReader(file);
            waveOut.Init(wavReader);
            waveOut.Play();
            double lastPercentComplete = 0;
            while(wavReader.CurrentTime != wavReader.TotalTime)
            {
                //ms version
                //Console.Write($"{mp3Reader.CurrentTime}ms / {mp3Reader.TotalTime}ms");

                //percentage version
                double percentComplete = Math.Round((wavReader.CurrentTime/wavReader.TotalTime)*100, 0);
                if(percentComplete != lastPercentComplete)
                {
                    lastPercentComplete = percentComplete;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(percentComplete + "%");
                }
            }
            Console.WriteLine("finished");
            waveOut.Stop();
        }
    
        public static void StopPlaying() //makes the output device stop playing whatever it's playing
        {
            waveOut.Stop();
            Console.WriteLine("playback halted");
            InputHandler.GetInput();
        }
        public static void PlayFile(string file) //a more flexible play file function that can offload picking what type of player to use from the caller
        {
            waveOut.Stop();
            try
            {
                string fileExtension = Path.GetExtension(file);
                if(fileExtension == ".mp3")
                {
                    PlayMP3File(file);
                }
                else if (fileExtension == ".wav")
                {
                    PlayWAVFile(file);
                }
                else 
                {
                    Console.WriteLine("Cannot play that file. (Likely in invalid file or invalid file type)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while attempting to play that file. Likely an invalid file type or restricted file access");
                Console.WriteLine($"Exception thrown: {e}");
                InputHandler.GetInput();
            }
        }
        public static void SkipTrack() //will skip the track playing
        {
            waveOut.Stop();
            if(MusicFiles.q.Count == 0)
            {
                Console.WriteLine("There is no song in queue to skip to");
            }
            else 
            {
                MusicFiles.q.Remove(MusicFiles.q[0]);
                PlayFile(MusicFiles.q[0]);
            }
            InputHandler.GetInput();
        }
    }
}