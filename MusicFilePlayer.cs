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
                Console.SetCursorPosition(0,Console.CursorTop);
                Console.Write($"{mp3Reader.CurrentTime}ms / {mp3Reader.TotalTime}ms");

                /*should support decimal percentages. Not sure how to round to even percentages though
                double percentComplete = Math.Round((mp3Reader.CurrentTime/mp3Reader.TotalTime)*100, 3);
                Console.Write(percentComplete + "%");
                */
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
        
        //makes the output device stop playing whatever it's playing
        public static void StopPlaying()
        {
            waveOut.Stop();
        }
        public static void PlayFile(string file)
        {
            try
            {
                string fileExtension = Path.GetExtension(file);
                if(fileExtension == ".mp3")
                {
                    PlayMP3File(file);
                }
                else if (fileExtension == ".wav");
                {
                    PlayWAVFile(file);
                }
            }
            catch
            {

            }
        }
}