using System.Collections.Generic;
using System.IO;

namespace LogStitcher
{
    public class FileProcessor
    {
        public FileProcessor(string file)
        {
            File = new FileInfo(file);
        }

        public FileInfo File { get; }

        public IEnumerable<Line> ReadLines()
        {
            using (var stream = File.OpenRead())
            using (var sr = new StreamReader(stream))
            {
                string text = null;
                var lastLine = new Line(string.Empty, File, null);
                while ((text = sr.ReadLine()) != null)
                {
                    var curLine = new Line(text, File, lastLine);
                    lastLine = curLine;
                    yield return curLine;
                }
            }
        }
    }
}