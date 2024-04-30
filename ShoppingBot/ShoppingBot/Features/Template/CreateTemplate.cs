using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template
{
    internal partial class TemplateSlashCommands
    {
        [SlashCommand("create-template", "Create template from the server")]
        public async Task CreateTemplate(InteractionContext ctx)
        {
            var template = await ctx.Guild.CreateTemplateAsync("template");
            await ctx.Channel.SendMessageAsync(template.SourceGuild.SplashUrl);
        }
    }
}
