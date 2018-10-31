using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Addons.Interactive;
using System.Threading;

namespace RiskBot.Modulues
{
    public class drakeBot : InteractiveBase
    {
        [Command("begonethots", RunMode = RunMode.Async)]
        public async Task begone()
        {
            bool canKick = false;
            foreach(var role in Context.Guild.GetUser(Context.User.Id).Roles)
            {
                if(role.Name == "House Tennant")
                {
                    canKick = true;
                }
            }
            if (canKick)
            {
                var users = Context.Guild.Users;
                bool isHouseMember = false;

                foreach (var user in users)
                {
                    foreach (var role in user.Roles)
                    {
                        if (role.Name == "House Tennant")
                        {
                            isHouseMember = true;
                        }
                    }
                    if (!isHouseMember && !user.IsBot)
                    {
                        try
                        {
                            await user.KickAsync("Not house member");
                        }
                        catch
                        {
                            await Context.Channel.SendMessageAsync($"Failed to kick {user.Mention}");
                        }
                    }
                }
            }
        }
    }
}
