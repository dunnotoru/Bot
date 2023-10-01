using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Interfaces;
using System.Text.RegularExpressions;

namespace Bot.Parsers
{
    internal class NstuScheduleHtmlParser : IHtmlParser
    {
        public async Task<string> ParseAsync(string htmlPage)
        {
            Regex dayRegex = new Regex(@"schedule__table-day.+>(..)<");
            Regex dateRegex = new Regex(@"schedule__table-date.+>(.....)<");
            Regex timeRegex = new Regex(@"schedule__table-time.+>(.{11})<");
            Regex itemRegex = new Regex(@"schedule__table-item.+>\s+(.+)&.+>(.+)<.+\s+.+>(.+)<.+\s+.+>(.+)<");

            MatchCollection dayMatches = dayRegex.Matches(htmlPage);
            MatchCollection dateMatches = dateRegex.Matches(htmlPage);
            MatchCollection timeMatches = timeRegex.Matches(htmlPage);
            MatchCollection itemMatches = itemRegex.Matches(htmlPage);

            foreach (Match d in dayMatches)
                Console.WriteLine(d.Groups[1].Value);

            foreach (Match d in dateMatches)
                Console.WriteLine(d.Groups[1].Value);

            foreach (Match d in timeMatches)
                Console.WriteLine(d.Groups[1].Value);

            foreach (Match d in itemMatches)
            {
                Console.WriteLine(d.Groups[1].Value);
                Console.WriteLine(d.Groups[2].Value);
                Console.WriteLine(d.Groups[3].Value);
                Console.WriteLine(d.Groups[4].Value);
            }

            return "";
        }

        
    }
}
