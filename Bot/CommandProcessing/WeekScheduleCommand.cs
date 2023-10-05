using ScheduleBot.Interfaces;
using ScheduleBot.WebClient;
using ScheduleBot.Parsers;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleBot.CommandProcessing
{
    internal class WeekScheduleCommand : IBotCommand
    {
        private readonly string _commandName = "/week_schedule";
        public bool CanProcess(IBotCommandArgs command)
        {
            return command.Name == _commandName;
        }

        public async Task ProcessCommand(IBotCommandArgs command)
        {
            if(!CanProcess(command))
                throw new ArgumentException(null, nameof(command));

            Client client = new Client(new BotConfiguration().AppConfiguration["NstuUrl"]);
            string htmlPage = await client.GetHtml();
            IScheduleParser Parser = new NstuScheduleHtmlParser(htmlPage);

            InlineKeyboardButton inlineKeyboardButton = new InlineKeyboardButton("Тык")
            {
                Url = client.UriString
            };

            List<InlineKeyboardButton> buttonsRow = new List<InlineKeyboardButton>()
            {
                inlineKeyboardButton
            };

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(buttonsRow);

            await command.Client.SendTextMessageAsync(
                    chatId: command.UserMessage.Chat.Id,
                    text: await Parser.ParseWeekAsync(),
                    replyMarkup: keyboardMarkup
                    );
        }

    }
}
