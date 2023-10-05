namespace ScheduleBot.Interfaces
{
    public interface IBotCommand
    {
        public Task ProcessCommand(IBotCommandArgs commandArgs);
        public bool CanProcess(IBotCommandArgs commandArgs);
    }
}
