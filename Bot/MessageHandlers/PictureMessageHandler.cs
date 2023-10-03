using Telegram.Bot;
using Telegram.Bot.Types;
using Bot.Interfaces;

namespace Bot.MessageHandlers
{
    internal class PictureMessageHandler : IMessageHandler
    {
        public IMessageHandler Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (message.Photo != null)
            {
                Console.WriteLine("Picture");
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Ну и кринжатина"
                    );
            }
            else if (Successor != null)
            {
                await Successor.HandleMessage(botClient, message);
            }
        }
    }
}
