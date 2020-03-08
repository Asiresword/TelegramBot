using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace TelegramBot.Handlers
{
    public class BotEventsHandler
    {
        public static MessageHandler TextHandler { get; set; } = new TextMessageHandler();
        public async static void BotMessageReceived(object sender, MessageEventArgs e)
        {
            await Task.Run(() => BotEventsHandler.TextHandler.HandleMessage(e.Message));
        }
    }
}
