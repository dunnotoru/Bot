using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Interfaces
{
    internal interface IResponseGenerator
    {
        public Task GenerateResponseAsync(ITelegramBotClient botClient, Update update);
    }
}
