using System;
using Bot.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Text;

namespace Bot.Parsers
{
    internal class NstuScheduleHtmlParser : IHtmlParser
    {
        public async Task<string> ParseAsync(string htmlPage)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlPage);

            HtmlNode table = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/main/div[2]/div[3]/div[2]");
            
            HtmlNodeCollection scheduleTableRow = table.ChildNodes;

            Regex r = new Regex(@"(\d\d:\d\d-\d\d:\d\d)(\D+)(\d-\d{0,3})\d-");

            StringBuilder sb = new StringBuilder();

            foreach (HtmlNode sch in scheduleTableRow)
            {
                if(sch.Name != "div")
                    continue;

                string data = sch.InnerText.Replace("\n", "").
                    Replace("\t", "").
                    Replace("&middot;", "").
                    Replace("&nbsp", "");

                string date = data.Substring(0, 7);
                data = data.Substring(7, data.Length - 7);

                MatchCollection matches = r.Matches(data);
                
                List<ScheduleCell> cells = new List<ScheduleCell>();
                for (int i = 0; i < matches.Count; i++)
                    cells.Add(new ScheduleCell(
                        matches[i].Groups[1].Value,
                        matches[i].Groups[2].Value,
                        matches[i].Groups[3].Value
                        ));

                DaySchedule d = new DaySchedule(cells, date);

                sb.AppendLine(d.GetFormattedString());
            }
            return sb.ToString();
        }
    }
}
