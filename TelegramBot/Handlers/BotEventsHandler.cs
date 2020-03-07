using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot.Handlers
{
    public static class BotEventsHandler
    {
        public async static void BotMessageReceived(object sender, MessageEventArgs e)
        {
            Message ReceivedMessage = e.Message;

            Console.WriteLine($"[{ReceivedMessage.From.FirstName} {ReceivedMessage.From.LastName}]: {ReceivedMessage.Text}");
            await Bot.TelegramBot.SendTextMessageAsync(ReceivedMessage.From.Id, ReceivedMessage.Text);
        }
    }
}
