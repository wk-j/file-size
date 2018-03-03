using System;
using System.IO;

namespace FileSize
{
    class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine($"Error - invalid arguments");
                return -1;
            }

            var file = args[0];

            if (!File.Exists(file))
            {
                Console.WriteLine($"Error - {file} is not exist");
                return -1;
            }

            double toKb(double i) => i / 1024.0;
            double toMb(double i) => toKb(i) / 1024.0;
            double toGb(double i) => toMb(i) / 1024.0;

            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            var size = new FileInfo(file).Length + 0.0;
            var format = string.Format(" {0} BYTE, {1:0.###} KB, {2:0.###} MB, {3:0.###} GB ",
                size,
                toKb(size),
                toMb(size),
                toGb(size));

            Console.WriteLine(format);

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            return 0;
        }
    }
}
