using Bot.Interfaces;
using Bot.WebClient;
using Bot.Parsers;

namespace Bot.CommandProcessing
{
    internal class TodayScheduleCommand : IBotCommand
    {
        private readonly string _commandName = "/today_schedule";
        public bool CanProcess(IBotCommandArgs command)
        {
            return command.Name == _commandName;
        }

        public async Task<string> ProcessCommand(IBotCommandArgs command)
        {
            if (!CanProcess(command))
                throw new ArgumentException(nameof(command));

            Client client = new Client();
            string htmlPage = await client.GetScheduleHtml();
            IScheduleParser Parser = new NstuScheduleHtmlParser(htmlPage);

            return await Parser.ParseTodayAsync();
        }
    }
}
