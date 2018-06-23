using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CompagnaBot
{
    public class CommandHandler
    {
        
        DiscordSocketClient Client;
        CommandService Service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {

            Client = client;
            Service = new CommandService();
            await Service.AddModulesAsync(Assembly.GetEntryAssembly());
            Client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {

            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(Client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos) || msg.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {

                var result = await Service.ExecuteAsync(context, argPos);
                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {

                    Console.WriteLine(result.ErrorReason);

                }

            }

        }
    }
}
