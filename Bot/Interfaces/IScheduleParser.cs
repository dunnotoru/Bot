namespace ScheduleBot.Interfaces
{
    public interface IScheduleParser
    {
        Task<string> ParseWeekAsync();
        Task<string> ParseTodayAsync();
    }
}
