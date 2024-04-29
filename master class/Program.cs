// See https://aka.ms/new-console-template for more information

using master_class;

var api = new OpenAiApi();
var telegramApi = new TelegramApi();

var offset = 0;
while (true)
{
    Thread.Sleep(100);
    var updates = await telegramApi.GetUpdates(offset);
    if (!updates.Any())
    {
        continue;
    }

    foreach (var update in updates)
    {
        var question = update.Message.Text;
        var response = await api.GetOpenAiResponse(question);

        await telegramApi.SendResponse(response, update);
    }

    offset = updates.Max(x => x.Id) + 1;
}
