using Bot.Interfaces;

namespace Bot.CommandProcessing
{
    internal class HelpCommand : IBotCommand
    {
        private readonly string _commandName = "/help";
        private readonly string _respondText = "Помощь.";
        public bool CanProcess(IBotCommandArgs command)
        {
            return command.Name == _commandName;
        }

        public async Task<string> ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(nameof(command));

            return _respondText;
        }
    }
}
