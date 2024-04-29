using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template
{
    internal partial class TemplateSlashCommands
    {
        [SlashCommand("remove-template", "Remove template from the server")]
        public async Task RemoveTemplate(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            try
            {
                await ctx.Guild.DeleteAllChannelsAsync();
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Template operation reponse",
                    Description = $"Template delete operation successed",
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
            catch (Exception)
            {
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Template operation reponse",
                    Description = $"Template delete operation failed",
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
        }
    }
}
