// See https://aka.ms/new-console-template for more information

using MasterClass.OpenAIService;
using MasterClass.TelegramSerevice;

var openAISerevice = new OpenAIService();
var telegramService = new TelegramService();
int offset = 0;

while (true)
{
    Thread.Sleep(100);
    var updates = await telegramService.GetUpdates(offset);
    if (!updates.Any())
    {
        continue;
    }

    foreach (var update in updates)
    {
        var response = await openAISerevice.GetAutocomplete(update.Message.Text);
        await telegramService.Respond(response, update);
    }

    offset = updates.Max(u => u.Id) + 1;
}
