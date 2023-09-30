using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Interfaces;
using System.Text.RegularExpressions;

namespace Bot.Parsers
{
    internal class ScheduleHtmlParser : IHtmlParser
    {
        private Regex _regex;
        public async Task<string> ParseAsync(string htmlPage)
        {
            _regex = new Regex(
                @"<div class=\042schedule__table-day\042 data-today=\042false\042>(..)<span class=\042schedule__table-date\042>(25.09)</span> </div>"
                );

            MatchCollection matches = _regex.Matches(htmlPage);
            string result = "";

            foreach(Match m in matches)
            {
                result = m.Groups[1].Value + m.Groups[2].Value;
                Console.WriteLine(result);
            }
            
            return result;
        }
    }
}
