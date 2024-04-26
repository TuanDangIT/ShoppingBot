using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using ShoppingBot.Features.Product.EditProductDescriptionByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template.UseTemplate
{
    internal class UseTemplateSlashCommand : ApplicationCommandModule
    {
        [SlashCommand("use-template", "Use template on the server")]
        public async Task UseTemplate(InteractionContext ctx, [Option("template-name", "Template's name")] string name)
        {
            
        }
    }
}
