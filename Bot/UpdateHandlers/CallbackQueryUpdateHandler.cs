using ScheduleBot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleBot.UpdateHandlers
{
    internal class CallbackQueryUpdateHandler : IUpdateHandler
    {
        public Task HandleUpdate(ITelegramBotClient botClient, Update update)
        {
            return default;
        }
    }
}
