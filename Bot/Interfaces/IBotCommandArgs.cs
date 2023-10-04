using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Interfaces
{
    internal interface IBotCommandArgs
    {
        public string Name { get; }
        public ITelegramBotClient Client { get; }
        public Message UserMessage { get; }
    }
}
