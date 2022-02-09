using CovidTelegramBot.BotCommands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CovidTelegramBot.Controllers
{
    [Route("/")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private ITelegramBotClient telegramBotClient;
        private ITelegramCommandService telegramCommandService;

        public TelegramBotController(ITelegramBotClient telegramBotClient, 
            ITelegramCommandService telegramCommandService)
        {
            this.telegramBotClient = telegramBotClient;
            this.telegramCommandService = telegramCommandService;
        }

        [HttpGet]
        public IActionResult Get() => Ok("Started");

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null) 
                return Ok();

            foreach (ITelegramCommand command in telegramCommandService.GetCommands())
            {
                if (command.Contains(update.Message))
                {
                    await command.ExecuteCommand(update.Message, telegramBotClient);
                    break;
                }
            }

            return Ok();
        }
    }
}
