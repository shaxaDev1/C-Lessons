using Telegram.Bot;
using Telegram.Bot.Types;

string botToken = "5706935992:AAG_FlaASvDc-KFx84tf4L4hsj4UIsuuhJc";

var bot = new TelegramBotClient(botToken);

bot.SendTextMessageAsync(661794537, "Hayir");
bot.StartReceiving(errorHandler: ErrorHandler, updateHandler: MessageHandlar);

async Task MessageHandlar(ITelegramBotClient client, Update update, CancellationToken token)
{
    Console.WriteLine(update.Message.Text);
    bot.SendTextMessageAsync(update.Message.Chat.Id, $"Xayir {update.Message.From.FirstName}");
}

async Task ErrorHandler(ITelegramBotClient client, Exception exc, CancellationToken token)
{

}

Console.ReadKey();