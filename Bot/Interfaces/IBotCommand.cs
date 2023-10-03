namespace Bot.Interfaces
{
    internal interface IBotCommand
    {
        public Task<string> ProcessCommand(IBotCommandArgs commandArgs);
        public bool CanProcess(IBotCommandArgs commandArgs);
    }
}
