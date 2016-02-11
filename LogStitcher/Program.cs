using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LogStitcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine($"Usage:  {Process.GetCurrentProcess().ProcessName} [File1] [File2] ...");
                return;
            }

            var processors = args.SelectMany(a => ExpandFilePaths(a)).Select(f => new FileProcessor(f)).ToList();

            var allLines = processors.SelectMany(p => p.ReadLines()).OrderBy(l => l.Date);

            foreach (var line in allLines)
            {
                Console.WriteLine($"{line.SourceName} | {line.Text}");
            }
        }

        private static IEnumerable<string> ExpandFilePaths(string arg)
        {
            var substitutedArg = System.Environment.ExpandEnvironmentVariables(arg);

            var dirPart = Path.GetDirectoryName(substitutedArg);
            if (dirPart.Length == 0)
                dirPart = ".";

            var filePart = Path.GetFileName(substitutedArg);

            foreach (var filepath in Directory.GetFiles(dirPart, filePart))
            {
                yield return filepath;
            }
        }
    }
}