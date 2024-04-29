using OpenAI_API;
using OpenAI_API.Chat;

namespace master_class;

public class OpenAiApi
{
    private OpenAIAPI api;
    private Conversation conversation;

    public OpenAiApi()
    {
        api = new OpenAIAPI("your token from the OpenAI");
        conversation = api.Chat.CreateConversation();
    }

    public async Task<string> GetOpenAiResponse(string question)
    {
        conversation.AppendUserInput(question);

        string response;
        try
        {
            response = await conversation.GetResponseFromChatbotAsync();
        }
        catch (Exception e)
        {
            response = "There was an error getting response from OpenAI API. " + e.Message;
        }

        return response;
    }
}
