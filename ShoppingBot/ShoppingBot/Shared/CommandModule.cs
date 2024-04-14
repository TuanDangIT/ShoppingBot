using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.DTOs;
using ShoppingBot.Entities.Interfaces;
using ShoppingBot.Features.Order.CreateOrder;
using ShoppingBot.Features.Order.EditOrderProductById;
using ShoppingBot.Features.Order.GetAllOrders;
using ShoppingBot.Features.Order.GetOrderById;
using ShoppingBot.Features.Product.DeleteProductByName;
using ShoppingBot.Shared.Abstractions;
using ShoppingBot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared
{
    internal class CommandModule : ApplicationCommandModule
    {
        protected readonly IMediator _mediator;

        public CommandModule(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Get<T>(InteractionContext ctx, IQuery<T> query)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(query);
            DiscordEmbedBuilder outputEmbed;
            if (result.IsSuccess && result.Value != null)
            {
                if(result.Value is ProductDto productDto)
                {
                    outputEmbed = new DiscordEmbedBuilder
                    {
                        Color = DiscordColor.Green,
                        Title = $"{productDto.Name}",
                        Description = $"{productDto.Description}",
                        Footer = new DiscordEmbedBuilder.EmbedFooter()
                        {
                            Text = $"Last updated : {productDto.LastUpdatedAt} (UTC +02:00), Created at: {productDto.CreatedAt} (UTC +02:00)"
                        }
                    }.AddField(nameof(productDto.Price), productDto.Price.ToString("F"), true);

                    if (productDto.ImageUrl != null && productDto.ImageUrl.Contains("https"))
                    {
                        outputEmbed.ImageUrl = productDto.ImageUrl;
                    }
                }else if(result.Value is OrderDto orderDto)
                {
                    outputEmbed = new DiscordEmbedBuilder
                    {
                        Color = DiscordColor.Green,
                        Title = $"{orderDto.Id}",
                        Description = $"{orderDto.Product.Name}",
                        Footer = new DiscordEmbedBuilder.EmbedFooter()
                        {
                            Text = $"Last updated : {orderDto.LastUpdatedAt} (UTC +02:00), Created at: {orderDto.CreatedAt} (UTC +02:00)"
                        }
                    }.AddField(nameof(orderDto.Product), orderDto.Product.Name, true);
                }
                else
                {
                    outputEmbed = default!;
                }
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} get operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n" +
                        $"{result.Error.Code}: {result.Error.Description}"
                    }

                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        public async Task GetAll<T>(InteractionContext ctx, IQuery<IEnumerable<T>> query,
            string batch)
            where T : class, IAuditable
        {
            await ctx.DeferAsync();
            int i = 1;
            var pageList = new List<Page>();
            do
            {
                StringBuilder sb = new StringBuilder();
                var serverId = ctx.Guild.Id;
                var results = await _mediator.Send(query);
                if (results.IsFailure)
                {
                    break;
                }
                //foreach (var item in results.Value)
                //{
                //    sb.Append($"{item.Id}, {item.Buyer}, {item.Product.Name} \n");
                //}
                var page = new Page("", new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{nameof(T)} operation response",
                    Description = batch
                });
                pageList.Add(page);
                i++;
            } while (true);
            if (pageList.Count == 0)
            {
                var outputEmbed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Green,
                    Title = $"Prder operation response",
                    Description = "Order list is empty"
                };
                await ctx.EditResponseAsync(new DiscordWebhookBuilder()
                    .AddEmbed(outputEmbed));
            }
            else
            {
                await ctx.Channel.SendPaginatedMessageAsync(ctx.Member, pageList);
            }
        }
        public async Task Delete<T>(InteractionContext ctx, ICommand command)
        {
            await ctx.DeferAsync();
            DiscordEmbedBuilder outputEmbed;
            var serverId = ctx.Guild.Id;
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} delete operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n" +
                        $"{result.Error.Code}: {result.Error.Description}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} delete operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    
        public async Task Create<T>(InteractionContext ctx, ICommand command)
        {
            await ctx.DeferAsync();
            var serverId = ctx.Guild.Id;
            var buyerName = ctx.User.Username;
            var result = await _mediator.Send(command);
            var outputEmbed = new DiscordEmbedBuilder();
            if (result.IsFailure)
            {
                IValidationResult validationResult = (IValidationResult)result;
                StringBuilder resultsStringBuilder = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    resultsStringBuilder.Append($"{error.Code}: {error.Description}\n");
                }
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} operation failed!",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = "Additional information:\n" +
                        $"{resultsStringBuilder}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} operation successed!"
                };
            }

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        public async Task Edit<T>(InteractionContext ctx, ICommand command)
        {
            await ctx.DeferAsync();
            DiscordEmbedBuilder outputEmbed;
            var serverId = ctx.Guild.Id;
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{nameof(T)} operation response",
                    Description = "{nameof(T)} edit operation failed",
                    Footer = new DiscordEmbedBuilder.EmbedFooter()
                    {
                        Text = $"Additional information: \n" +
                        $"{result.Error.Code}: {result.Error.Description}"
                    }
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"{nameof(T)} operation response",
                    Description = $"{nameof(T)} edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }

}
