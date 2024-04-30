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
        [SlashCommand("use-ecommerce-template", "Use prepered template for e-commerce")]
        public async Task UseTemplate(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            try
            {
                await ctx.Guild.DeleteAllChannelsAsync();
                var administrationSection = await ctx.Guild.CreateChannelCategoryAsync("Administration section");
                var generalSection = await ctx.Guild.CreateChannelCategoryAsync("General section");
                var clientSection = await ctx.Guild.CreateChannelCategoryAsync("Client section");
                var ticketSection = await ctx.Guild.CreateChannelCategoryAsync("Ticket section");  
                var administrationTextChannel = await ctx.Guild.CreateChannelAsync("Administration commands", DSharpPlus.ChannelType.Text, administrationSection);
                var administrationRoom = await ctx.Guild.CreateChannelAsync("Administration room", DSharpPlus.ChannelType.Voice, administrationSection);
                var general = await ctx.Guild.CreateChannelAsync("Administration commands", DSharpPlus.ChannelType.Text, generalSection);
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

