﻿using Bot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.CommandProcessing
{
    internal class HelpCommand : IBotCommand
    {
        private readonly string _commandName = "/help";
        private readonly string _respondText = "Помощь.";
        public bool CanProcess(IBotCommandArgs command)
        {
            return command.Name == _commandName;
        }

        public async Task ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(nameof(command));

            await command.Client.SendTextMessageAsync(
                    chatId: command.UserMessage.Chat.Id,
                    text: _respondText
                    );
        }
    }
}
