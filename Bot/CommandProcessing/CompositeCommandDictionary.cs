using ScheduleBot.Interfaces;

namespace ScheduleBot.CommandProcessing
{
    internal class CompositeCommandDictionary 
    {
        private Dictionary<string, IBotCommand> Processors { get; set; }
            

        public CompositeCommandDictionary()
        {
            Processors = new Dictionary<string, IBotCommand>();
        } 
        public void Register(string commandName, IBotCommand processor)
        {
            Processors.Add(commandName, processor);
        }

        public bool CanProcess(IBotCommandArgs command)
        {
            return Processors.ContainsKey(command.Name);
        }
        
        public async Task ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(null, nameof(command));

            await Processors[command.Name].ProcessCommand(command);
        }
    }
}
