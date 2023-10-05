using ScheduleBot.Interfaces;
using ScheduleBot.Parsers;
using ScheduleBot.CommandProcessing;
using ScheduleBot.UpdateHandlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleBot.UpdateHandlers
{
    internal class MessageUpdateHandler : IUpdateHandler
    {

        public MessageUpdateHandler()
        {

        }

        public async Task HandleUpdate(ITelegramBotClient botClient, Update update)
        {
            IMessageHandler commandHandler = new CommandHandler();
            IMessageHandler textHandler = new TextMessageHandler();
            IMessageHandler pictureHandler = new PictureMessageHandler();
            IMessageHandler stickerHandler = new StickerMessageHandler();
            IMessageHandler unknownHandler = new UnknownMessageHandler();

            commandHandler.Successor = textHandler;
            textHandler.Successor = pictureHandler;
            pictureHandler.Successor = stickerHandler;
            stickerHandler.Successor = unknownHandler;

            
            Message message = update.Message;
            await commandHandler.HandleMessage(botClient, message);
        }
    }
}
