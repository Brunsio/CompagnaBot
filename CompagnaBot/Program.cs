using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace CompagnaBot
{
    public class Program
    {
        
        DiscordSocketClient Client;
        CommandHandler Handler;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();
            
        public async Task StartAsync()
        {

            if (Config.bot.token == "" || Config.bot.token == null) return;
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            Client.Log += Log;
            await Client.LoginAsync(TokenType.Bot, Config.bot.token);
            await Client.StartAsync();
            Handler = new CommandHandler();
            await Handler.InitializeAsync(Client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
