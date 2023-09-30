using Telegram.Bot;
using Telegram.Bot.Types;
using Bot.Interfaces;

namespace Bot.MessageHandlers
{
    internal class TextMessageHandler : IMessageHandler
    {
        public IMessageHandler Successor { get; set; }
        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                Console.WriteLine("Text");

                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text
                    );
            }
            else if(Successor != null)
            {
                await Successor.HandleMessage(botClient,message);
            }
        }
    }
}
