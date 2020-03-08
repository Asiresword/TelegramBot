using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Handlers.MessageHandlers
{
    public class TextMessageHandler : MessageHandler
    {
        public TextMessageHandler(MessageHandler Successor = null) : base(Successor) { }
        
        private bool IsCommand(string Text)
        {
            return Text[0] == '/';
        }

        private InlineKeyboardMarkup GetPatternKeyboard()
        {
            return new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Factory Method"),
                    InlineKeyboardButton.WithCallbackData("Abstract Factory")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Singleton"),
                    InlineKeyboardButton.WithCallbackData("Prototype")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Builder"),
                    InlineKeyboardButton.WithCallbackData("Strategy")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Observer"),
                    InlineKeyboardButton.WithCallbackData("Command")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Template Method"),
                    InlineKeyboardButton.WithCallbackData("Iterator")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("State"),
                    InlineKeyboardButton.WithCallbackData("Chain Of Responsibility")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Interpreter"),
                    InlineKeyboardButton.WithCallbackData("Mediator")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Memento"),
                    InlineKeyboardButton.WithCallbackData("Visitor")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Decorator"),
                    InlineKeyboardButton.WithCallbackData("Adapter")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Facade"),
                    InlineKeyboardButton.WithCallbackData("Composite")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Proxy"),
                    InlineKeyboardButton.WithCallbackData("Bridge")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Flyweight")
                },
            });
        }

        public override async void HandleMessage(Message ReceivedMessage)
        {
            if(ReceivedMessage.Type == MessageType.Text)
            {
                Console.WriteLine($"[{ReceivedMessage.From.FirstName} {ReceivedMessage.From.LastName}]: {ReceivedMessage.Text}");
                
                if(IsCommand(ReceivedMessage.Text))
                {
                    switch(ReceivedMessage.Text)
                    {
                        case "/start":
                            await Bot.TelegramBot.SendTextMessageAsync(ReceivedMessage.From.Id, "Hello.\n/patterns - List of patterns.");
                            break;
                        case "/patterns":
                            await Bot.TelegramBot.SendTextMessageAsync(ReceivedMessage.From.Id, "Choose the pattern.", replyMarkup: GetPatternKeyboard());
                            break;
                    }

                    return;
                }

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
