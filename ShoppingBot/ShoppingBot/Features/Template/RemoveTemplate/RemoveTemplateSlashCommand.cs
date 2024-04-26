using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template.RemoveTemplate
{
    internal class RemoveTemplateSlashCommand : ApplicationCommandModule
    {
        [SlashCommand("remove-template", "Remove template from the server")]
        public async Task RemoveTemplate(InteractionContext ctx, [Option("template-name", "Template's name")] string name)
        {
            
        }
    }
}
