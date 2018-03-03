using System;
using System.IO;

namespace FileSize {

    enum Unit { Byte, KB, MB, GB, ZZ }
    class Program {

        static ConsoleColor fg = Console.ForegroundColor;
        static ConsoleColor bg = Console.BackgroundColor;

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
                return (Unit.ZZ, "Invalid argument");
            }
        }

        static void DisplaySize(Unit unit, double size) {

            double toKb(double i) => i / 1024.0;
            double toMb(double i) => toKb(i) / 1024.0;
            double toGb(double i) => toMb(i) / 1024.0;

            void setColor(ConsoleColor f, ConsoleColor b) {
                Console.ForegroundColor = f;
                Console.BackgroundColor = b;
            }

            void print(double value) {
                Console.WriteLine(String.Format("{0:0.###} {1}", value, unit));
            }

            setColor(ConsoleColor.White, ConsoleColor.DarkBlue);

            if (unit == Unit.Byte) {
                print(size);
            } else if (unit == Unit.KB) {
                print(toKb(size));
            } else if (unit == Unit.MB) {
                print(toMb(size));
            } else if (unit == Unit.GB) {
                print(toGb(size));
            }

            setColor(fg, bg);
        }

        public static int Main(string[] args) {

            var (unit, file) = ParseCommands(args);

            if (unit == Unit.ZZ) {
                Console.WriteLine("Error - {0}", file);
                return -1;
            }

            if (!File.Exists(file)) {
                Console.WriteLine("Error - File \"{0}\" is not exist", file);
                return -1;
            }

            DisplaySize(unit, new FileInfo(file).Length);

            return 0;
        }
    }
}
