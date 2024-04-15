namespace MasterClass.OpenAIService;

public class OpenAIRequest
{
    public string Model { get; set; }
    public List<Message> Messages { get; set; }
}
