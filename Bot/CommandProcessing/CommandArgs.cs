using Bot.Interfaces;

namespace Bot.CommandProcessing
{
    internal class CommandArgs : IBotCommandArgs
    {
        public string Name { get; private set; }
        public CommandArgs(string name)
        {
            Name = name;
        }
    }
}
