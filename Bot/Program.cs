using System;


namespace ScheduleBot
{
    internal class Program
    {
        static async Task Main()
        {
            BotConfiguration config = new BotConfiguration();
            string token = config.AppConfiguration["BotToken"];
            ScheduleBot bot = new ScheduleBot(token);

            await bot.Run();
        }

    }
}