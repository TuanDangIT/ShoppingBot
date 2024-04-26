using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template.GetAllTemplates
{
    internal class GetAllTemplatesSlashCommand : ApplicationCommandModule
    {
        [SlashCommand("get-all-templatse", "Get all templates")]
        public async Task GetAllTemplates(InteractionContext ctx)
        {

        }
    }
}
