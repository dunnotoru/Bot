using Telegram.Bot;
using Telegram.Bot.Types;
using Bot.Interfaces;

using Bot.Parsers;

namespace Bot.MessageHandlers
{
    internal class TextMessageHandler : IMessageHandler
    {
        public IMessageHandler Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                await ProcessMessage(botClient, message);
            }
            else if(Successor != null)
            {
                await Successor.HandleMessage(botClient,message);
            }
        }

        private async Task ProcessMessage(ITelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text
                    );
        }
    }
}
