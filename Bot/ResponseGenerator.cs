using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Bot.Interfaces;
using Bot.MessageHandlers;

namespace Bot
{
    internal class ResponseGenerator : IResponseGenerator
    {
        public async Task GenerateResponseAsync(ITelegramBotClient botClient, Update update)
        {
            IMessageHandler commandHandler = new CommandMessageHandler();
            IMessageHandler textHandler = new TextMessageHandler();
            IMessageHandler pictureHandler = new PictureMessageHandler();
            IMessageHandler stickerHandler = new StickerMessageHandler();
            IMessageHandler unknownHandler = new UnknownMessageHandler();

            commandHandler.Successor = textHandler;
            textHandler.Successor = pictureHandler;
            pictureHandler.Successor = stickerHandler;
            stickerHandler.Successor = unknownHandler;

            switch (update.Type)
            {
                case UpdateType.Message:
                    await commandHandler.HandleMessage(botClient, update.Message);
                    break;
            }
        }
    }
}
