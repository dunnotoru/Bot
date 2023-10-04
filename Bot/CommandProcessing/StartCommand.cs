using Bot.Interfaces;
using Telegram.Bot;

namespace Bot.CommandProcessing
{
    internal class StartCommand : IBotCommand
    {
        private readonly string _commandName = "/start";
        private readonly string _respondText = "Здравствуй!";
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
