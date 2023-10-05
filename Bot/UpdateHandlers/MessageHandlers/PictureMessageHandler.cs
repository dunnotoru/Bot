using Telegram.Bot;
using Telegram.Bot.Types;
using ScheduleBot.Interfaces;

namespace ScheduleBot.UpdateHandlers.MessageHandlers
{
    internal class PictureMessageHandler : IMessageHandler
    {
        public IMessageHandler? Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Ну и кринж ахахах"
                    );
            }
            else if (Successor != null)
            {
                await Successor.HandleMessage(botClient, message);
            }
        }
    }
}
