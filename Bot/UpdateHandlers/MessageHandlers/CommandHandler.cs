using ScheduleBot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using ScheduleBot.CommandProcessing;

namespace ScheduleBot.UpdateHandlers.MessageHandlers
{
    internal class CommandHandler : IMessageHandler
    {
        public IMessageHandler? Successor { get; set; }
        private readonly CompositeCommandDictionary _commandProcessor = new CompositeCommandDictionary();

        public CommandHandler()
        {
            _commandProcessor.Register("/week_schedule", new WeekScheduleCommand());
            _commandProcessor.Register("/today_schedule", new TodayScheduleCommand());
            _commandProcessor.Register("/start", new StartCommand());
            _commandProcessor.Register("/help", new HelpCommand());
        }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (!string.IsNullOrEmpty(message.Text)
                && message.Text.StartsWith('/'))
            {
                await _commandProcessor.ProcessCommand(
                    new CommandArgs(message.Text,
                    botClient,
                    message));
            }
            else if(Successor != null)
            {
                await Successor.HandleMessage(botClient, message);
            }
        }
    }
}
