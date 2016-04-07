using NAudio.Wave;
using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        private static string wav_file_path = @".\test.wav";

        static void Main(string[] args)
        {
            FileStream wav_file_stream = File.OpenRead(wav_file_path);

            // Reset the stream to the beginning
            wav_file_stream.Seek(0, SeekOrigin.Begin);

            WaveStream ws_raw = new WaveFileReader(wav_file_stream);
            ws_raw = WaveFormatConversionStream.CreatePcmStream(ws_raw);
            WaveOutEvent output = new WaveOutEvent();
            output.Init(ws_raw);
            output.Play();

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}
