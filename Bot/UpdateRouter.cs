using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ScheduleBot.Interfaces;

namespace ScheduleBot
{
    internal class UpdateRouter
    {
        private Dictionary<UpdateType, IUpdateHandler> Handlers { get; set; }
            = new Dictionary<UpdateType, IUpdateHandler>();

        public UpdateRouter(Dictionary<UpdateType, IUpdateHandler> handlers)
        {
            Handlers = handlers;
        }

        public async Task RouteUpdate(ITelegramBotClient botClient, Update update)
        {
            if(Handlers.ContainsKey(update.Type))
                await Handlers[update.Type].HandleUpdate(botClient, update);
        }
    }
}
