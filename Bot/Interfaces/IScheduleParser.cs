namespace Bot.Interfaces
{
    internal interface IScheduleParser
    {
        Task<string> ParseWeekAsync();
        Task<string> ParseTodayAsync();
        Task<string> ParseDateAsync(DayOfWeek dayOfWeek);
    }
}
