using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleBot.Interfaces
{
    public interface IBotCommandArgs
    {
        public string Name { get; }
        public ITelegramBotClient Client { get; }
        public Message UserMessage { get; }
    }
}
