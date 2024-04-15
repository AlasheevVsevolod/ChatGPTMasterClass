using Telegram.Bot;
using Telegram.Bot.Types;

namespace MasterClass.TelegramSerevice;


public class TelegramService
{
    private const string botId = "id of your telegram bot";

    public async Task<Update[]> GetUpdates(int offset)
    {
        var client = new TelegramBotClient(botId);
        var updates = await client.GetUpdatesAsync(offset);
        return updates;
    }

    public async Task Respond(string response, Update originalMessage)
    {
        const long chatIdToForward = -123456789;
        var client = new TelegramBotClient(botId);
        await client.SendTextMessageAsync(
            originalMessage.Message.Chat.Id,
            response,
            replyToMessageId: originalMessage.Message.MessageId);
        var forwardedMessage = await client.ForwardMessageAsync(
            new ChatId(chatIdToForward),
            originalMessage.Message.Chat.Id,
            originalMessage.Message.MessageId);
        await client.SendTextMessageAsync(
            new ChatId(chatIdToForward),
            response,
            replyToMessageId: forwardedMessage.MessageId);

    }
}
