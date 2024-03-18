using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingBot.DAL;
using ShoppingBot.Features.Product.AddProduct;
using ShoppingBot.Features.Product.DeleteProductByName;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using ShoppingBot.Features.Product.EditProductImageUrlByName;
using ShoppingBot.Features.Product.EditProductPriceByName;
using ShoppingBot.Features.Product.GetAllProducts;
using ShoppingBot.Features.Product.GetProductByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Commands
{
    [SlashCommandGroup("product", "Product operations")]
    internal class ProductSlashCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;

        public ProductSlashCommands(IMediator mediator)
        {
            _mediator = mediator;
        }
        [SlashCommand("add-product", "Add a product")]
        public async Task AddProduct(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price, [Option("description", "Item description")] string description, [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new AddProductCommand(name, price, description, imageUrl));
            var outputEmbed = new DiscordEmbedBuilder();
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = $"Product operation failed!"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = $"Product operation successed!"
                };
            }

          
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("get-all-products", "Get all products")]
        public async Task GetAllProducts(InteractionContext ctx)
        {
            //uproszczona wersja na razie
            await ctx.DeferAsync();
            var results = await _mediator.Send(new GetAllProductsQuery());
            StringBuilder resultsStringBuilder = new StringBuilder();
            foreach (var item in results.Value)
            {
                resultsStringBuilder.Append($"{item.Name}, {item.Price} \n");
            }
            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = $"Product operation response",
                Description = resultsStringBuilder.ToString()
            };
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("delete-product", "Delete a product")]
        public async Task DeleteProductByName(InteractionContext ctx,
            [Option("name", "Item name")]string name)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new DeleteProductByNameCommand(name));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product delete operation failed"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product delete operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("edit-product-price", "Edit a product's price")]
        public async Task EditProductPriceByName(InteractionContext ctx, [Option("name", "Item name")] string name,
            [Option("price", "Item price")] double price)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new EditProductPriceByNameCommand(name, price));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation failed"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("edit-product-description", "Edit a product's description")]
        public async Task EditProductDescriptionByName(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("description", "Item description")] string description)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new EditProductDescriptionByNameCommand(name, description));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation failed"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("edit-product-imageurl", "Edit a product's image URL")]
        public async Task EditProductImageUrlByName(InteractionContext ctx, [Option("name", "Item name")] string name
            , [Option("image-url", "Url link to the image")] string imageUrl)
        {
            await ctx.DeferAsync();
            var outputEmbed = new DiscordEmbedBuilder();
            var result = await _mediator.Send(new EditProductImageUrlByNameCommand(name, imageUrl));
            if (result.IsFailure)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation failed"
                };
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = "Product edit operation successed"
                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
        [SlashCommand("get-product-by-name", "Get a product by name")]
        public async Task GetProductByName(InteractionContext ctx,
            [Option("name", "Item name")] string name)
        {
            await ctx.DeferAsync();
            var result = await _mediator.Send(new GetProductByNameQuery(name));
            var outputEmbed = new DiscordEmbedBuilder();
            if(result.IsSuccess && result.Value != null)
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Green,
                    Title = $"Product operation response",
                    Description = $"{result.Value.Name}, {result.Value.Price}",
                    
                };
                if(result.Value.ImageUrl != null && result.Value.ImageUrl.Contains("https"))
                {
                    outputEmbed.ImageUrl = result.Value.ImageUrl;
                }
            }
            else
            {
                outputEmbed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Red,
                    Title = $"Product operation response",
                    Description = $"Product not found",

                };
            }
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed));
        }
    }
}
