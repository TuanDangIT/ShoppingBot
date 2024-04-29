using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.DTOs;
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
        [SlashCommand("use-template", "Use template on the server")]
        public async Task UseTemplate(InteractionContext ctx, [Option("template-name", "Template's name")] string name)
        {
            await ctx.DeferAsync();
            try
            {
                var category = await ctx.Guild.CreateChannelCategoryAsync("Akcje administratora");
                await ctx.Guild.CreateChannelAsync("Komendy administratora", DSharpPlus.ChannelType.Text, category);
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Template operation reponse",
                    Description = $"Template use operation successed",
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
            catch (Exception)
            {
                var outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Template operation reponse",
                    Description = $"Template use operation failed",
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
            }
        }
    }
}

