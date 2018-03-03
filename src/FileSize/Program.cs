using System;
using System.IO;

namespace FileSize {

    enum Unit { Byte, KB, MB, GB }
    class Program {

        private static (Unit, string) ParseCommands(string[] args) {

            if (args.Length == 1) {
                return (Unit.KB, args[0]);
            } else if (args.Length == 2) {
                var u = args[0];
                var file = args[1];
                if (u == "-b") return (Unit.Byte, file);
                else if (u == "-m") return (Unit.MB, file);
                else if (u == "-g") return (Unit.GB, file);
                else return (Unit.KB, file);
            } else {
                throw new Exception("Error - Invalid argument");
            }
        }

        public static int Main(string[] args) {

            double toKb(double i) => i / 1024.0;
            double toMb(double i) => toKb(i) / 1024.0;
            double toGb(double i) => toMb(i) / 1024.0;

            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            var (unit, file) = ParseCommands(args);
            if (!File.Exists(file)) {
                throw new Exception($"Error - File \"{file}\" not exist");
            }

            var size = new FileInfo(file).Length;

            if (unit == Unit.Byte) {
                Console.WriteLine(String.Format("{0} {1}", size, unit));
            } else if (unit == Unit.KB) {
                Console.WriteLine(String.Format("{0:0.###} {1}", toKb(size), unit));
            } else if (unit == Unit.MB) {
                Console.WriteLine(String.Format("{0:0.###} {1}", toMb(size), unit));
            } else if (unit == Unit.GB) {
                Console.WriteLine(String.Format("{0:0.###} {1}", toGb(size), unit));
            }

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            return 0;
        }
    }
}
