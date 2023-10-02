using Telegram.Bot;
using Telegram.Bot.Types;
using Bot.Interfaces;
using Bot.WebClient;
using Bot.Parsers;

namespace Bot.MessageHandlers
{
    internal class TextMessageHandler : IMessageHandler
    {
        public IMessageHandler Successor { get; set; }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                await ProcessMessage(botClient, message);
            }
            else if(Successor != null)
            {
                await Successor.HandleMessage(botClient,message);
            }
        }

        private async Task ProcessMessage(ITelegramBotClient botClient, Message message)
        {
            if (message.Text.ToLower() == "week")
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: await GetWeekSchedule()
                    );
            }
            else if (message.Text.ToLower() == "today")
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: await GetDaySchedule()
                    );
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text
                    );
            }
        }

        private async Task<string> GetWeekSchedule()
        {
            Client client = new Client();
            string htmlPage = await client.GetScheduleHtml();
            IHtmlScheduleParser Parser = new NstuScheduleHtmlParser(htmlPage);
            return await Parser.ParseWeekAsync();
        }

        private async Task<string> GetDaySchedule()
        {
            Client client = new Client();
            string htmlPage = await client.GetScheduleHtml();
            IHtmlScheduleParser Parser = new NstuScheduleHtmlParser(htmlPage);
            return await Parser.ParseTodayAsync();
        }
    }
}
