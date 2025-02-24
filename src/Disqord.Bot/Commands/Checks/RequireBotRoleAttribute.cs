﻿using System.Linq;
using System.Threading.Tasks;
using Qmmands;

namespace Disqord.Bot
{
    /// <summary>
    ///     Specifies that the module or command can only be executed if the bot has the given role.
    /// </summary>
    public class RequireBotRoleAttribute : DiscordGuildCheckAttribute
    {
        public Snowflake Id { get; }

        public RequireBotRoleAttribute(ulong id)
        {
            Id = id;
        }

        public override ValueTask<CheckResult> CheckAsync(DiscordGuildCommandContext context)
        {
            if (context.CurrentMember.RoleIds.Any(x => x == Id))
                return Success();

            return Failure($"The bot requires the role with ID {Id}.");
        }
    }
}
