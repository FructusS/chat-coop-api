using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using web_api_for_chat_on_signalr;
using web_api_for_chat_on_signalr.Models;

public class ChatHub : Hub
{
    private readonly ApplicationContext _context;
    public ChatHub(ApplicationContext context)
    {

        _context = context;

    }

    public async Task SendMessage(string user, string message)
    {

        await Clients.All.SendAsync("ReceiveMessage", user, message);
        _context.Messages.Add(new web_api_for_chat_on_signalr.Models.Message()
        { MessageContent = message, UserName = user });
        await _context.SaveChangesAsync();
    }
    public async Task JoinChat(string user)
    {

        await Clients.All.SendAsync("Join", user);

    }
    public async Task LeaveChat(string user)
    {

        await Clients.All.SendAsync("Leave", user);

    }
    public async Task< IEnumerable<Message>> GetMessageHistory()
    {
        var messageHistory = _context.Messages.Take(20)
                .AsEnumerable()
                .Reverse()
                .ToList();

        return messageHistory;
            }
}