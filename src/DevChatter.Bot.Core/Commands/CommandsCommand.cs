﻿using System.Collections.Generic;
using System.Linq;
using DevChatter.Bot.Core.Data.Model;
using DevChatter.Bot.Core.Events;
using DevChatter.Bot.Core.Systems.Chat;

namespace DevChatter.Bot.Core.Commands
{
    public class CommandsCommand : BaseCommand
    {
        public CommandsCommand()
            : base(UserRole.Everyone, "commands", "cmd")
        {
        }

        public IEnumerable<IBotCommand> AllCommands { get; set; }

        public override void Process(IChatClient chatClient, CommandReceivedEventArgs eventArgs)
        {
            var listOfCommands = AllCommands.Where(x => eventArgs.ChatUser.CanUserRunCommand(x)).Select(x => $"!{x.PrimaryCommandText}").ToList();

            string stringOfCommands = string.Join(", ", listOfCommands);
            chatClient.SendMessage($"These are the commands that {eventArgs.ChatUser.DisplayName} is allowed to run: ({stringOfCommands})");
        }
    }
}
