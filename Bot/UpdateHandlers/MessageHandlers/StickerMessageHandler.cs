using Telegram.Bot;
using Telegram.Bot.Types;
using ScheduleBot.Interfaces;

namespace ScheduleBot.UpdateHandlers.MessageHandlers
{
    internal class StickerMessageHandler : IMessageHandler
    {
        public IMessageHandler? Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (message.Sticker != null)
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Нормально общайся"
                    );
            }
            else if (Successor != null)
            {
                await Successor.HandleMessage(botClient, message);
            }
        }
    }
}
