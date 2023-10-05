using Telegram.Bot.Types;
using Telegram.Bot;

namespace ScheduleBot.Interfaces
{
    internal interface IUpdateHandler
    {
        public Task HandleUpdate(ITelegramBotClient botClient, Update update);
    }
}
