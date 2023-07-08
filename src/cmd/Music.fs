namespace JunoBot.Commands

open DSharpPlus
open DSharpPlus.Net
open DSharpPlus.CommandsNext
open DSharpPlus.CommandsNext.Attributes
open DSharpPlus.Lavalink
open System.Threading.Tasks

type Music() =
    inherit BaseCommandModule()

    [<Command "ping">]
    [<Description "Test the bot's connection">]
    let ping (ctx: CommandContext) : Task =
        task { ctx.RespondAsync("pong!") |> ignore }
