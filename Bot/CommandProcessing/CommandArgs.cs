using Bot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.CommandProcessing
{
    internal class CommandArgs : IBotCommandArgs
    {
        public string Name { get; private set; }

        public ITelegramBotClient Client { get; private set; }

        public Message UserMessage {get; private set; }

        public CommandArgs(string name, ITelegramBotClient client,
            Message userMessage)
        {
            Name = name;
            Client = client;
            UserMessage = userMessage;
        }
    }
}
