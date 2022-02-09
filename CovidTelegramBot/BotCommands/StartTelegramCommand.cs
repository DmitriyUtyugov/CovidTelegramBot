using CovidTelegramBot.BotCommands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CovidTelegramBot.BotCommands
{
    public class StartTelegramCommand : ITelegramCommand
    {
        public string Name => @"/start";

        public bool Contains(Message message)
        {
            return message.Type == MessageType.Text
                ? message.Text.Contains(Name)
                : false;
        }

        public async Task ExecuteCommand(Message message, ITelegramBotClient telegramBotClient)
        {
            await telegramBotClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                         text: "this is a start command");
        }
    }
}
