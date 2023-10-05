using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using ScheduleBot.Interfaces;
using ScheduleBot.UpdateHandlers;

namespace ScheduleBot
{
    public class ScheduleBot
    {
        private TelegramBotClient _botClient;
        private ReceiverOptions _receiverOptions;
        private UpdateRouter _updateRouter;

        public ScheduleBot(string token)
        {
            _botClient = new TelegramBotClient(token);

            _receiverOptions = new ReceiverOptions
            {
                ThrowPendingUpdates = true
            };

            _updateRouter = new UpdateRouter(
                new Dictionary<UpdateType, Interfaces.IUpdateHandler>()
                {
                    {UpdateType.Message, new MessageUpdateHandler() },
                    {UpdateType.CallbackQuery, new CallbackQueryUpdateHandler() }
                }
                );
        }

        public async Task Run()
        {
            using var cts = new CancellationTokenSource();

            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);

            User me = await _botClient.GetMeAsync();
            Console.WriteLine($"{me.FirstName} started!");

            await Task.Delay(-1);
        }

        private async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                await _updateRouter.RouteUpdate(botClient, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

    }
}
