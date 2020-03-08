using System.Threading.Tasks;
using TelegramBot.Handlers.MessageHandlers;
using Telegram.Bot.Args;
using TelegramBot.Handlers.CallbackHandlers;

namespace TelegramBot.Handlers
{
    public static class BotEventsHandler
    {
        public static MessageHandler TextHandler { get; set; } = new TextMessageHandler();
        public async static void BotMessageReceived(object sender, MessageEventArgs e)
        {
            await Task.Run(() => BotEventsHandler.TextHandler.HandleMessage(e.Message));
        }

        public async static void BotCallbackReceived(object sender, CallbackQueryEventArgs e)
        {
            string Response = await CallbackPatternHandler.GetPattern(e.CallbackQuery.Data);

            await Bot.TelegramBot.SendTextMessageAsync(e.CallbackQuery.From.Id, Response);
        }
    }
}
