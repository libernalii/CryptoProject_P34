using Microsoft.AspNetCore.Mvc;

namespace AIChat.WebApi.Controllers;

[ApiController]
[Route("api/v1/chat")]
public class ChatController : ControllerBase
{
    private readonly OpenAiChatService _openAiChatService;

    public ChatController(OpenAiChatService openAiChatService)
    {
        _openAiChatService = openAiChatService;
    }

    [HttpPost("message")]
    public async Task<IActionResult> PostMessage(ChatRequest request)
    {
        var response = await _openAiChatService.Message(request.Message);
        return Ok(response);
    }
}

public class ChatRequest
{
    public string Message { get; set; }
}