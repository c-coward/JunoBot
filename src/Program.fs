namespace JunoBot

open System.Threading.Tasks
open DisCatSharp
open DisCatSharp.CommandsNext
open DisCatSharp.Net
open DisCatSharp.Lavalink

open Configuration
open JunoBot.Commands

module Program =
    open DisCatSharp.Enums
    [<EntryPoint>]
    let main argv =
        printfn "JunoBot: Starting up"

        let token = appConfig.Token
        let config = DiscordConfiguration()
        config.Token <- token
        config.TokenType <- TokenType.Bot

        config.Intents <-
            DiscordIntents.AllUnprivileged
            ||| DiscordIntents.MessageContent
            ||| DiscordIntents.GuildMessageReactions

        let client = new DiscordClient(config)
        printfn "JunoBot: Client configured"

        let cmdConfig = CommandsNextConfiguration()
        cmdConfig.StringPrefixes <- ResizeArray(["~"])

        let cmd = client.UseCommandsNext(cmdConfig)
        cmd.RegisterCommands<Music>()
        printfn "JunoBot: Commands configured"

        printfn "JunoBot: Attempting Discord connection... "
        client.ConnectAsync() |> Async.AwaitTask |> Async.RunSynchronously

        printfn "JunoBot: Attempting Lavalink connection... "
        let _ = Task.Delay(15000) |> Async.AwaitTask |> Async.RunSynchronously // Give Lavalink time to spin up
        let lava = client.UseLavalink()

        let lavaConfig =
            let configuration = LavalinkConfiguration()

            let endpoint =
                ConnectionEndpoint(appConfig.Lavalink.Hostname, appConfig.Lavalink.Port)

            configuration.Password <- appConfig.Lavalink.Password
            configuration.RestEndpoint <- endpoint
            configuration.SocketEndpoint <- endpoint
            configuration

        let lavaConnection =
            lava.ConnectAsync lavaConfig |> Async.AwaitTask |> Async.RunSynchronously

        printfn "JunoBot: Bot ready to deploy"
        Task.Delay(-1) |> Async.AwaitTask |> Async.RunSynchronously
        printfn "JunoBot: Terminating connection. Goodbye!"

        1
