using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MasterClass.OpenAIService;

public class OpenAIService
{
    public async Task<string> GetAutocomplete(string question)
    {
        var httpClient = new HttpClient();
        var openAIToken = "your token from the OpenAI";
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAIToken);

        var request = new OpenAIRequest()
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<Message>()
            {
                new Message()
                {
                    Role = "user",
                    Content = question,
                }
            }
        };

        var response = await httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", request);
        var deserializedResponse = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

        return deserializedResponse.Choices.First().Message.Content;
    }
}
