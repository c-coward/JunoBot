namespace JunoBot.Commands

open DisCatSharp
open DisCatSharp.Net
open DisCatSharp.CommandsNext
open DisCatSharp.CommandsNext.Attributes
open DisCatSharp.Lavalink
open System.Threading.Tasks

open JunoBot.Util.Music

type Music() =
    inherit BaseCommandModule()

    [<Command "ping">]
    [<Description "Test the bot's connection">]
    member this.Ping(ctx: CommandContext, [<RemainingText>] txt: string) : Task =
        task { ctx.RespondAsync("Pong!") |> ignore }

    // member this.Join(ctx: CommandContext) : Task =
    //     task {
    //         let node = getLavaNode ctx
    //         return ()
    //     }
