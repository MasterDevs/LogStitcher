using System;
using System.IO;
using System.Linq;

namespace LogStitcher
{
    public class Line
    {
        public Line(string text, FileInfo file, Line lastLine)
        {
            // sample line:  02/10/2016 11:42:44.511 | 91418 | INFO  | Outlook sync run completed

            Text = text;
            SourceName = file.Name;
            var parts = text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            Date = parts.Select(p => TryGetDate(p)).FirstOrDefault() ?? lastLine?.Date ?? DateTime.MinValue;
        }

        public DateTime Date { get; }

        public string SourceName { get; }

        public string Text { get; }

        private DateTime? TryGetDate(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            return null;
        }
    }
}