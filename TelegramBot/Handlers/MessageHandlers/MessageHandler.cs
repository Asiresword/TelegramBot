using System;
using Telegram.Bot.Types;

namespace TelegramBot.Handlers.MessageHandlers
{
    public abstract class MessageHandler
    {
        protected MessageHandler Successor { get; set; }
        public MessageHandler(MessageHandler Successor = null)
        {
            this.Successor = Successor;
        }

        public abstract void HandleMessage(Message ReceivedMessage);

        public virtual async void ErrorHandlingMessage(Message ReceivedMessage)
        {
            Console.WriteLine("\t-----------------------------");
            Console.WriteLine("\t| Unable to handle message. |");
            Console.WriteLine($"\t| Message type: { ReceivedMessage.Type} |");
            Console.WriteLine($"\t| Message sender: {ReceivedMessage.From.FirstName} {ReceivedMessage.From.LastName} |");
            Console.WriteLine("\t-----------------------------");

            await Bot.TelegramBot.SendTextMessageAsync(ReceivedMessage.From.Id, "Sorry, i don't understand you."); 
        }
        public virtual void SetSuccessor(MessageHandler Handler)
        {
            this.Successor = Handler;
        }
    }
}
