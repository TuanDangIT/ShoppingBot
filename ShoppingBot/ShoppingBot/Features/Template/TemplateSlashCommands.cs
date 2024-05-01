using DSharpPlus.SlashCommands;
using MediatR;
using ShoppingBot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.Template
{
    [SlashCommandGroup("template", "Template operations")]
    internal partial class TemplateSlashCommands : ApplicationCommandModule
    {
    }
}
