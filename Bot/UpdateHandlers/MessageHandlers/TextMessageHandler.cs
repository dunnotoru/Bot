﻿using Telegram.Bot;
using Telegram.Bot.Types;
using ScheduleBot.Interfaces;

namespace ScheduleBot.UpdateHandlers.MessageHandlers
{
    internal class TextMessageHandler : IMessageHandler
    {
        public IMessageHandler? Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text
                    );
            }
            else if (Successor != null)
            {
                await Successor.HandleMessage(botClient, message);
            }
        }
    }
}