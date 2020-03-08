using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace TelegramBot.Handlers
{
    public class TextMessageHandler : MessageHandler
    {
        public TextMessageHandler(MessageHandler Successor = null) : base(Successor) { }
        public override async void HandleMessage(Message ReceivedMessage)
        {
            if(ReceivedMessage.Type == MessageType.Text)
            {
                Console.WriteLine($"[{ReceivedMessage.From.FirstName} {ReceivedMessage.From.LastName}]: {ReceivedMessage.Text}");
                await Bot.TelegramBot.SendTextMessageAsync(ReceivedMessage.From.Id, ReceivedMessage.Text);
            }
            else if(this.Successor != null)
            {
                this.Successor.HandleMessage(ReceivedMessage);
            }
            else
            {
                await Task.Run(() => ErrorHandlingMessage(ReceivedMessage));
            }
        }
    }
}
