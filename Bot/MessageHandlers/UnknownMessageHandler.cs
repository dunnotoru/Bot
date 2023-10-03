using Telegram.Bot;
using Telegram.Bot.Types;
using Bot.Interfaces;

namespace Bot.MessageHandlers
{
    internal class UnknownMessageHandler : IMessageHandler
    {
        public IMessageHandler Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Сложна"
                    );
        }
    }
}
