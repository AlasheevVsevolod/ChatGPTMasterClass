using Telegram.Bot;
using Telegram.Bot.Types;

namespace master_class;

public class TelegramApi
{
    TelegramBotClient botClient;
    
    public TelegramApi()
    {
        botClient = new TelegramBotClient("id of your telegram bot");
    }

    public async Task<Update[]> GetUpdates(int offset)
    {
        var updates = await botClient.GetUpdatesAsync(offset);
        return updates;
    }

    public async Task SendResponse(string response, Update originalMessage)
    {
        var myChatId = "-123456789";
        await botClient.SendTextMessageAsync(
            originalMessage.Message.Chat.Id,
            response,
            replyToMessageId: originalMessage.Message.MessageId);

        var forwardedMessage = await botClient.ForwardMessageAsync(
            myChatId,
            originalMessage.Message.Chat.Id,
            originalMessage.Message.MessageId);

        await botClient.SendTextMessageAsync(
            myChatId,
            response,
            replyToMessageId: forwardedMessage.MessageId);
    }
}
