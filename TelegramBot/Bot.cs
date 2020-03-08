using System;
using TelegramBot.Handlers;
using Telegram.Bot;
using TelegramBot.API;

namespace TelegramBot
{
    public class Bot
    {
        public static TelegramBotClient TelegramBot { get; set; }
        internal static void Main()
        {
            TelegramBot = new TelegramBotClient(new APIAuthLocal().GetKey());
            TelegramBot.OnMessage += BotEventsHandler.BotMessageReceived;
            TelegramBot.OnCallbackQuery += BotEventsHandler.BotCallbackReceived;

            Console.WriteLine($"Bot have been started.\nName: {TelegramBot.GetMeAsync().Result.FirstName}\nTime: {DateTime.Now}\n");

            TelegramBot.StartReceiving();

            Console.ReadKey();

            TelegramBot.StopReceiving();
        }
    }
}
