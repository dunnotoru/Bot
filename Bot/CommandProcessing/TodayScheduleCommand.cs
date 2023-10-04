using Bot.Interfaces;
using Bot.WebClient;
using Bot.Parsers;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.CommandProcessing
{
    internal class TodayScheduleCommand : IBotCommand
    {
        private readonly string _commandName = "/today_schedule";
        public bool CanProcess(IBotCommandArgs command)
        {
            return command.Name == _commandName;
        }

        public async Task ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(nameof(command));

            Client client =
                new Client("https://www.nstu.ru/studies/schedule/schedule_classes/schedule?group=%D0%90%D0%92%D0%A2-113");

            string htmlPage = await client.GetHtml();
            IScheduleParser Parser = new NstuScheduleHtmlParser(htmlPage);

            InlineKeyboardButton inlineKeyboardButton = new InlineKeyboardButton("Тык");
            inlineKeyboardButton.CallbackData = "Button \"Тык\" has been pressed";
            inlineKeyboardButton.Url = client.UriString;

            List<InlineKeyboardButton> buttonsRow = new List<InlineKeyboardButton>()
            {
                inlineKeyboardButton
            };

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(buttonsRow);
            

            await command.Client.SendTextMessageAsync(
                    chatId: command.UserMessage.Chat.Id,
                    text: await Parser.ParseTodayAsync(),
                    replyMarkup: keyboardMarkup
                    );
        }
    }
}
