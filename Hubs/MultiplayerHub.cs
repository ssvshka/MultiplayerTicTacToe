using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using MultiplayerTicTacToe.Models;

namespace MultiplayerTicTacToe.Hubs
{
    public class MultiplayerHub : Hub
    {
        public Task SendTurn(Square square)
        {
            return Clients.All.SendAsync("GetTurn", square);
        }
    }
}
