using Bot.Interfaces;

namespace Bot.CommandProcessing
{
    internal class CompositeCommandDictionary
    {
        Dictionary<string, IBotCommand> _processors = new Dictionary<string, IBotCommand>();
        public void Register(string commandName, IBotCommand processor)
        {
            _processors.Add(commandName, processor);
        }

        public bool CanProcess(IBotCommandArgs command)
        {
            return _processors.ContainsKey(command.Name);
        }
        
        public async Task ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(nameof(command));

            await _processors[command.Name].ProcessCommand(command);
        }
    }
}
