using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace RyeChan_MacOS
{
    class Program
    {
        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, "PRIVATE");

            await _client.StartAsync();

            Console.WriteLine("Logged In");

            _handler = new CommandHandler(_client);

            await _client.SetGameAsync("Say !help");

            await Task.Delay(-1);
        }
    }
}