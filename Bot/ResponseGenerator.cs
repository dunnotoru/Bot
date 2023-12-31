﻿using Telegram.Bot;
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
            IMessageHandler textHandler = new TextMessageHandler();
            IMessageHandler pictureHandler = new PictureMessageHandler();
            IMessageHandler stickerHandler = new StickerMessageHandler();
            IMessageHandler unknownHandler = new UnknownMessageHandler();

            textHandler.Successor = pictureHandler;
            pictureHandler.Successor = stickerHandler;
            stickerHandler.Successor = unknownHandler;

            switch (update.Type)
            {
                case UpdateType.Message:
                    await textHandler.HandleMessage(botClient, update.Message);
                    break;
            }
        }
    }
}
