namespace Bot.Interfaces
{
    internal interface IHtmlScheduleParser
    {
        Task<string> ParseWeekAsync();
        Task<string> ParseTodayAsync();
    }
}
