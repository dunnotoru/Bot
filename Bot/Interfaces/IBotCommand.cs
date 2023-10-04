namespace Bot.Interfaces
{
    internal interface IBotCommand
    {
        public Task ProcessCommand(IBotCommandArgs commandArgs);
        public bool CanProcess(IBotCommandArgs commandArgs);
    }
}
