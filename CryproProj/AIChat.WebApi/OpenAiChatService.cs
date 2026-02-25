using System.ClientModel;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;

namespace AIChat.WebApi;

public class OpenAiChatService
{
    private readonly OpenAIClient _openAIClient;
    private readonly string _model;

    public OpenAiChatService(IConfiguration configuration)
    {
        _openAIClient = new OpenAIClient(new ApiKeyCredential(configuration["OpenAi:ApiKey"]), 
            new OpenAIClientOptions
            {
                Endpoint = new Uri(configuration["OpenAi:Endpoint"])
            });
        _model = configuration["OpenAi:Model"];
    }
    
    public async Task<string> Message(string message)
    {
        var client = _openAIClient.GetChatClient(_model);

        var userMessage = ChatMessage.CreateUserMessage(message);
        
        var response = await client.CompleteChatAsync([userMessage]);

        return JsonSerializer.Serialize(response.Value);
    }
}