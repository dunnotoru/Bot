using System;

namespace Bot
{
    internal class Program
    {
        static private string _token = "6515990588:AAEeamU0mN_CvCG-TTjp4Y1olntKF6yTqJ0";
        static async Task Main()
        {
            ScheduleBot bot = new ScheduleBot(_token);

            await bot.Run();
        }

    }
}