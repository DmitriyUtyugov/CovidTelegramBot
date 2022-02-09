using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CovidTelegramBot.BotCommands.Interfaces
{
    public interface ITelegramCommand
    {
        string Name { get; }

        Task ExecuteCommand(Message message, ITelegramBotClient telegramBotClient);

        bool Contains(Message message);
    }
}
