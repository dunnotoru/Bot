using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleBot.Interfaces
{
    public interface IMessageHandler
    {
        public IMessageHandler? Successor { get; set; }
        public Task HandleMessage(ITelegramBotClient botClient, Message message);
    }
}
