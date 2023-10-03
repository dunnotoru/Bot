using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Interfaces
{
    internal interface IMessageHandler
    {
        public IMessageHandler Successor { get; set; }
        public Task HandleMessage(ITelegramBotClient botClient, Message message);
    }
}
