using ScheduleBot.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Text;

namespace ScheduleBot.Parsers
{
    internal class NstuScheduleHtmlParser : IScheduleParser
    {
        private string Html { get; set; }
        public NstuScheduleHtmlParser(string html)
        {
            Html = html;
        }

        public async Task<string> ParseWeekAsync()
        {
            StringBuilder sb = new StringBuilder();

            List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday,
            DayOfWeek.Wednesday, DayOfWeek.Thursday,DayOfWeek.Friday, DayOfWeek.Saturday};

            foreach (DayOfWeek day in days)
                sb.AppendLine(await ParseDateAsync(day));

            return sb.ToString();
        }

        public async Task<string> ParseTodayAsync()
        {
            return await ParseDateAsync(DateTime.Today.DayOfWeek);
        }

        public async Task<string> ParseDateAsync(DayOfWeek dayOfWeek)
        {
            Dictionary<DayOfWeek, string> day = new Dictionary<DayOfWeek, string>()
            {
                {DayOfWeek.Monday, "пн" },
                {DayOfWeek.Tuesday,"вт" },
                {DayOfWeek.Wednesday,"ср" },
                {DayOfWeek.Thursday,"чт" },
                {DayOfWeek.Friday, "пт" },
                {DayOfWeek.Saturday, "сб" },
            };

            StringBuilder sb = new StringBuilder();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Html);
            HtmlNode table = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/main/div[2]/div[3]/div[2]");
            Regex r = new Regex(@"(\d\d:\d\d-\d\d:\d\d)(\D+)(\d-\d{0,3})\d-");

            List<HtmlNode> scheduleDaysList = table.ChildNodes.Where(_ => _.Name == "div").ToList();
            
            string data = scheduleDaysList.First(
                _ => _.InnerText.Trim().StartsWith(day[dayOfWeek])).
                InnerText;

            data = data.Replace("\n", "").
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

            return sb.ToString();
        }
    }
}
